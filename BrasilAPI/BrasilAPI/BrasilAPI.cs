using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices; 
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BrasilAPI.Test")]

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    {
        public BrasilAPI()
        {
            Client = CreateHttpClient();
        } 
         
        #region Internal

        private const string BASE_URL = "https://brasilapi.com.br/api";
        private HttpClient Client;

        internal string OnlyNumbers(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return Regex.Replace(str, @"[^\d]", "");
        }

        private HttpClient CreateHttpClient(Dictionary<string, object> headers = null)
        {
            HttpClient client = new HttpClient();

            if (headers == null)
                headers = new Dictionary<string, object>();

            string userAgent = UserAgent();

            if (!string.IsNullOrWhiteSpace(userAgent))
                headers["user-agent"] = userAgent;

            if (headers.Any())
            {
                foreach (var header in headers)
                {
                    if (header.Value != null)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }

            }

            return client;
        }

        internal string UserAgent()
        {
            var thisLib = Assembly.GetExecutingAssembly().GetName();
            var userAgent = $"BrasilAPI.DotNet/{thisLib.Version}";
            return userAgent;
        }

        private async Task EnsureSuccess(HttpResponseMessage response, string url)
        {
            if ((int)response.StatusCode >= 400)
            {
                string contentString = await response.Content.ReadAsStringAsync();
                object content = contentString;
                string message = "Error while trying to access the BrasilAPI";

                try
                {
                    dynamic jsonObj = JsonConvert.DeserializeObject<object>(contentString);
                    content = jsonObj;
                    message = (string)jsonObj["message"];
                }
                catch (Exception)
                {

                }

                throw new BrasilAPIException(message)
                {
                    ContentData = content,
                    Code = (int)response.StatusCode,
                    URL = url
                };
            }
        }

        public void Dispose()
        {
            Client = null;
        }

        #endregion
    }
}

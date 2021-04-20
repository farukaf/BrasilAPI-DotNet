using System;
using System.Collections.Generic;
using System.Text;

namespace SDKBrasilAPI
{
    public class BrasilAPIException : Exception
    {
        public BrasilAPIException(string message) : base(message) { }

        public object ContentData { get; internal set; }

        public int Code { get; internal set; }

        public string URL { get; internal set; }
    }
}

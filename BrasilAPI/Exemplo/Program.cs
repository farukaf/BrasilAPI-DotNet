using SDKBrasilAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
    class Program
    {
        static void Main(string[] args)
        {
            Banks().Wait();
            CEP().Wait();
            CNPJ().Wait();
            DDD().Wait();
            Feriados().Wait();
            IBGE().Wait();

            Console.WriteLine("Finalizado...");
            Console.WriteLine("");
        }

        static async Task Banks()
        {
            Console.WriteLine("BrasilAPI.Banks");
            using (var brasilAPI = new BrasilAPI())
            {
                var bankResponse = await brasilAPI.Banks();

                Console.WriteLine("Encontrado {0} bancos.", bankResponse.Banks.Count());
                foreach (var bank in bankResponse.Banks.Take(5))
                {
                    Console.WriteLine("=> {0}", bank.Name);
                }

                Console.WriteLine("...");
                Console.WriteLine();
            }
        }

        static async Task CEP()
        {
            Console.WriteLine("BrasilAPI.CEP");
            using (var brasilAPI = new BrasilAPI())
            {
                var cepResponse = await brasilAPI.CEP_V2("89010025");
                var propInfo = cepResponse.GetType().GetProperties();

                foreach (var prop in propInfo)
                {
                    var val = prop.GetValue(cepResponse, null);
                    Console.WriteLine("{0}: {1}", prop.Name, val?.ToString());
                }

                Console.WriteLine();
            }
        }

        static async Task CNPJ()
        {
            Console.WriteLine("BrasilAPI.CNPJ");
            using (var brasilAPI = new BrasilAPI())
            {
                var cnpjResponse = await brasilAPI.CNPJ("00.000.000/0001-91");
                var propInfo = cnpjResponse.GetType().GetProperties();

                foreach (var prop in propInfo.Take(5))
                {
                    var val = prop.GetValue(cnpjResponse, null)?.ToString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        Console.WriteLine("{0}: {1}", prop.Name, val);
                    }
                }

                Console.WriteLine("...");
                Console.WriteLine();
            }
        }

        static async Task DDD(int code = 48)
        {
            Console.WriteLine("BrasilAPI.DDD");
            using (var brasilAPI = new BrasilAPI())
            {
                var dddResponse = await brasilAPI.DDD(code);

                Console.WriteLine("DDD: {0}", code);
                Console.WriteLine("UF: {0}", dddResponse.UF.ToString());
                foreach (var city in dddResponse.Cities.OrderBy(x => x).Take(5))

                {
                    Console.WriteLine("=> {0}", city);
                }

                Console.WriteLine("...");
                Console.WriteLine();
            }
        }

        static async Task Feriados(int ano = 2021)
        {
            Console.WriteLine("BrasilAPI.Feriados");
            using (var brasilAPI = new BrasilAPI())
            {
                var feriadoResponse = await brasilAPI.Feriados(ano);

                Console.WriteLine("Ano: {0}", ano);

                foreach (var item in feriadoResponse.Feriados)
                {
                    Console.WriteLine("{0}: {1}({2})", item.Date?.ToString(@"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), item.Name, item.Type);
                }

                Console.WriteLine();
            }
        }

        static async Task IBGE()
        {
            Console.WriteLine("BrasilAPI.IBGE");
            using (var brasilAPI = new BrasilAPI())
            {
                var ibgeResponse = await brasilAPI.IBGE_UF();

                foreach (var ibge in ibgeResponse.IBGEs)
                {
                    Console.WriteLine("{0}: {1}", ibge.Sigla, ibge.Nome);
                }

                Console.WriteLine();

                var ibgeMunicipiosResponse = await brasilAPI.IBGE_Municipios(UF.RR);

                foreach (var municipio in ibgeMunicipiosResponse.Municipios)
                {
                    Console.WriteLine("{0}: {1}", municipio.CodigoIBGE, municipio.Nome);
                }

                Console.WriteLine();
            }
        }
    } 

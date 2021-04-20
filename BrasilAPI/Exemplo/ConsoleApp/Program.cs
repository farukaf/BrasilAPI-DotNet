using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstTask = new List<Task>();
            lstTask.Add(Banks());

            Task.WaitAll(lstTask.ToArray());

            Console.WriteLine("Finalizado..."); 
        }

        static async Task Banks()
        {
            using (var brasilAPI = new BrasilAPI.BrasilAPI())
            {
                var bankResponse = await brasilAPI.Banks();

                Console.WriteLine("Encontrado {0} bancos.", bankResponse.Banks.Count());
                //pega os 5 primeiros bancos
                foreach (var bank in bankResponse.Banks.Take(5))
                {
                    Console.WriteLine("=> ", bank.Name);
                }
            }
        }
    }
}

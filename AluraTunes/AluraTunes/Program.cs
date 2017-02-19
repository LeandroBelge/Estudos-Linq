using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query = from nf in contexto.NotaFiscals
                            select nf;

                var query2 = query;

                query2 = query2.OrderByDescending(n => n.DataNotaFiscal);

                foreach (var item in query2)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.DataNotaFiscal, item.Cliente.PrimeiroNome, item.Total);
                }
            }
            Console.ReadKey();
        }
    }
}

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
                            orderby nf.Total descending, nf.Cliente.PrimeiroNome
                            select new
                            {
                                nfdata = nf.DataNotaFiscal,
                                nfCliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                                nfTotal = nf.Total
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.nfdata, item.nfCliente, item.nfTotal);
                }
            }
            Console.ReadKey();
        }
    }
}

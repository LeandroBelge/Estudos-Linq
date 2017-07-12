using AluraTunes.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                var queryMedia = contexto.NotaFiscals.Average(n => n.Total);

                var query =
                    from nf in contexto.NotaFiscals
                    where nf.Total > queryMedia//Subconsulta
                    orderby nf.Total descending
                    select new
                    {
                        Numero =  nf.NotaFiscalId,
                        Data = nf.DataNotaFiscal,
                        Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                        Valor = nf.Total
                    };

                foreach (var notaFiscal in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", notaFiscal.Numero, notaFiscal.Data, notaFiscal.Cliente, notaFiscal.Valor);
                }
                
                Console.WriteLine("A média é {0}", queryMedia);
            }
            
            Console.ReadKey();
        }

    }
}

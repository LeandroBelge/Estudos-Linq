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
                contexto.Database.Log = Console.WriteLine;

                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);
                Console.WriteLine("Venda média: {0}", vendaMedia);

                var query = from nf in contexto.NotaFiscals
                            orderby nf.Total
                            select nf.Total;

                var contagem = query.Count();
                var elementoCentral = query.Skip(contagem / 2).First();
                var mediana = elementoCentral;

                Console.WriteLine("Mediana: {0}", mediana);
            }
            Console.ReadKey();
        }
    }
}

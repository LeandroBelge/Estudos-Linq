using AluraTunes.Data;
using System;
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
                //contexto.Database.Log = Console.WriteLine;

                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);
                Console.WriteLine("Venda média: {0}", vendaMedia);

                var query = from nf in contexto.NotaFiscals
                            select nf.Total;

                var mediana = Mediana(query);

                Console.WriteLine("Mediana: {0}", mediana);

                var vendaMediana = contexto.NotaFiscals.Mediana(nf => nf.Total);
                Console.WriteLine("Mediana com método de extensão: {0}", vendaMediana);

            }
            Console.ReadKey();
        }

        private static decimal Mediana(IQueryable<decimal> query)
        {
            
            var contagem = query.Count();

            query = query.OrderBy(nf => nf);
            var elementoCentral_1 = query.Skip(contagem / 2).First();
            var elementoCentral_2 = query.Skip((contagem - 1) / 2).First();
            
            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            return mediana;
        }   
    }
    static class LinkExtensions
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
        {
            var contagem = source.Count();

            var funcSelector = selector.Compile();
            var query = source.Select(selector).OrderBy(nf => nf);

            var elementoCentral_1 = query.Skip(contagem / 2).First();
            var elementoCentral_2 = query.Skip((contagem - 1) / 2).First();

            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            return mediana;
        }
    }
}

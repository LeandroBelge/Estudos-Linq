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
                //Recuperar os funcionários em ordem alfabética
                var query = from f in contexto.Funcionarios
                            orderby f.PrimeiroNome 
                            select f;
                //imprime a lista de funcinários
                foreach (var item in query)
                {
                    Console.WriteLine(item.PrimeiroNome);
                }

                Console.WriteLine();
                //Imprime o primeiro funcionário da lista
                var primeiroLista = query.First().PrimeiroNome;

                Console.WriteLine(primeiroLista);

                Console.WriteLine();
                //Imprime o segundo funcionário da lista utilizando o métod extendido Second.
                var segundoLista = query.Second().PrimeiroNome;

                Console.WriteLine(segundoLista);
            }
            Console.ReadKey();
        }
    }

    static class LinkExtensions
    {
        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(1).First();
        }
    }   
}

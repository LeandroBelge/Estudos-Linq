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
                //Linq com sintaxe de método
                var query = contexto.Artistas.Where(a => a.Nome.Contains("Led"));

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.ArtistaId, item.Nome);
                }

                Console.WriteLine();
                //Linq com sintaxe de consulta
                var query2 = from a in contexto.Artistas
                             where a.Nome.Contains("Led")
                             select a;

                foreach (var item in query2)
                {
                    Console.WriteLine("{0}\t{1}", item.ArtistaId, item.Nome);
                }
            }

            Console.ReadKey();
        }
    }
}

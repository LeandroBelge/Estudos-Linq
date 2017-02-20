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
            //Linq to entities count
            using (var contexto = new AluraTunesEntities())
            {
                //Contando o resultado utilizando linq sintaxe de consulta
                var query = from f in contexto.Faixas
                            where f.Album.Artista.Nome == "Led Zeppelin"
                            select f;
                var quantidade = query.Count();
                Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade);

                Console.WriteLine();

                //Contando o resultado utilizando linq com sintaxe de método
                var quantidade2 = contexto.Faixas.Count(c => c.Album.Artista.Nome == "Led Zeppelin");

                Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade2);
            }
            Console.ReadKey();
        }
    }
}

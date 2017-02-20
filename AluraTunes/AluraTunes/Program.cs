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
                //groupby e comando let
                var query = from inf in contexto.Albums
                            group inf by inf.Artista into artista
                            orderby artista.Key.Nome ascending
                            select new
                            {
                                nome = artista.Key.Nome,
                                qtdeAlbuns = artista.Key.Albums.Count()
                            };
                            

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.nome.PadRight(100), item.qtdeAlbuns);
                }
            }
            Console.ReadKey();
        }
    }
}

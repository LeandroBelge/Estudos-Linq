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
                var query = from album in contexto.Albums
                            where album.Artista.Nome.Contains("Led")
                            select new 
                            {
                                albumTitulo = album.Titulo,
                                artistaNome = album.Artista.Nome
                            };

                //Modificando a consulta.
                query = query.Where(a => a.albumTitulo.Contains("Graffit"));

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.albumTitulo.PadRight(50), item.artistaNome);
                }
            }
            Console.ReadKey();
        }
    }
}

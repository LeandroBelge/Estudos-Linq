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
                //Relacionamento sem Join
                var query = from album in contexto.Albums
                            where album.Artista.Nome.Contains("Led")
                            select new
                            {
                                artistaId = album.ArtistaId,
                                artistaNome = album.Artista.Nome,
                                albumTitulo =  album.Titulo
                            };
                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.artistaId, item.artistaNome, item.albumTitulo);
                }
            }

            Console.ReadKey();
        }
    }
}

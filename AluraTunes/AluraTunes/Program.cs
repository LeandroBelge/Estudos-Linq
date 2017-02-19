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
                string nomeAlbum = "Presence";
                var query = from faixa in contexto.Faixas
                            where faixa.Album.Artista.Nome.Contains("Led")
                            && (!string.IsNullOrEmpty(nomeAlbum) ? faixa.Album.Titulo.Contains(nomeAlbum): true)
                            orderby faixa.Album.Titulo, faixa.Nome
                            select new 
                            {
                                faixaNome = faixa.Nome,
                                albumTitulo = faixa.Album.Titulo
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.albumTitulo.PadRight(50), item.faixaNome);
                }
            }
            Console.ReadKey();
        }
    }
}

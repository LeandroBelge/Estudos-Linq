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
                var query = from inf in contexto.ItemNotaFiscals
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            group inf by inf.Faixa.Album into agrupado
                            let vendasPorAlbum = agrupado.Sum(a => (a.Quantidade * a.PrecoUnitario))//A variável assume a expressão lambida como valor através do comando "let"
                            orderby  vendasPorAlbum descending
                            select new 
                            {    
                                tituloAlbum = agrupado.Key.Titulo,
                                total = vendasPorAlbum
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.tituloAlbum.PadRight(40), item.total);
                }
            }
            Console.ReadKey();
        }
    }
}

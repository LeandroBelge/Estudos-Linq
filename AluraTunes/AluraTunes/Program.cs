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
                //Utilizando o método Sum();
                var query = from inf in contexto.ItemNotaFiscals
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            select new 
                            {                    
                                totaItem = (inf.Quantidade * inf.PrecoUnitario)
                            };
                
                var totalArtista = query.Sum(t => t.totaItem);
                
                Console.WriteLine("Total do artista {0}", totalArtista);
            }
            Console.ReadKey();
        }
    }
}

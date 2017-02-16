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
            XElement xml =  XElement.Load(@"..\..\Data\AluraTunes.xml");

            var query = from m in xml.Element("Musicas").Elements("Musica")
                        join g in xml.Element("Generos").Elements("Genero")
                            on m.Element("GeneroId").Value equals g.Element("GeneroId").Value
                        select new
                            {
                                musicaId = m.Element("MusicaId").Value,
                                musicaNome = m.Element("Nome").Value,
                                generoNome = g.Element("Nome").Value
                            };
            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.musicaId, item.musicaNome, item.generoNome);
            }
          
            Console.ReadKey();
        }
    }
}

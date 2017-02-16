using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listar todos os sistemas da Tecsystem informando seu Id, Nome e o nome da sua categoria.
            XElement xml = XElement.Load(@"..\..\Data\SistemasTecsystem.xml");

            var query = from s in xml.Element("Sistemas").Elements("Sistema")
                         join c in xml.Element("Categorias").Elements("Categoria")
                             on s.Element("CategoriaId").Value equals c.Element("Id").Value
                         select new
                             {
                                 sistemaId = s.Element("Id").Value,
                                 sistemaNome = s.Element("Nome").Value,
                                 categoriaNome = c.Element("Nome").Value
                             };

            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.sistemaId, item.sistemaNome, item.categoriaNome);
            }
            
           
            Console.ReadKey();
        }
    }
}

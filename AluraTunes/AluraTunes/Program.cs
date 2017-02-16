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
            //Listar nome de modelos e seus fabricantes       
            XElement xml =  XElement.Load(@"..\..\Data\Automoveis.xml");

            //var query = from m in xml.Element("Modelos").Elements("Modelo")
            //            join f in xml.Element("Fabricantes").Elements("Fabricante")
            //                on m.Element("FabricanteId").Value equals f.Element("FabricanteId").Value
            //            select new
            //                {
            //                    modelo = m.Element("Nome").Value,
            //                    fabricante = f.Element("Nome").Value
            //                };

            var query = from f in xml.Element("Fabricantes").Elements("Fabricante")
                        select f;

            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.Element("FabricanteId").Value, item.Element("Nome").Value);
            }

            Console.ReadKey();
        }
    }
}

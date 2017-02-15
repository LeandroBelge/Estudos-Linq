﻿using System;
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
            //D:\Leandro\Projetos\Estudos Linq\AluraTunes\AluraTunes\Data
            XElement xml =  XElement.Load(@"..\..\Data\Automoveis.xml");

            var query = from m in xml.Element("Modelos").Elements("Modelo")
                        join f in xml.Element("Fabricantes").Elements("Fabricante")
                            on m.Element("FabricanteId").Value equals f.Element("FabricanteId").Value
                        select new
                            {
                                modelo = m.Element("Nome").Value,
                                fabricante = f.Element("Nome").Value
                            };
            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.modelo, item.fabricante);
            }

            Console.ReadKey();
        }
    }
}

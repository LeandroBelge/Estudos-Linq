using AluraTunes.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                var mesAniversario = 1;
                while (mesAniversario <= 12)
                {
                    
                    Console.WriteLine("Mês: {0}", mesAniversario);

                    var query = (from f in contexto.Funcionarios
                                where f.DataNascimento.Value.Month == mesAniversario
                                orderby f.DataNascimento.Value.Month, f.DataNascimento.Value.Day 
                                select f).ToList();//O método ToList() já compila a consulta, com isso a variável já guarda a resposta da consulta. 
                                                   //Sem o ToList() a consulta só seria realizada quando o foreach iniciasse. Então a consulta com o ToList() é de execução imediata. 
                    
                    foreach (var f in query)
                    {
                        Console.WriteLine("{0:dd/MM}\t{1} {2}", f.DataNascimento, f.PrimeiroNome, f.Sobrenome);
                    }
                    mesAniversario++;
                }
            }
            Console.ReadKey();
        }
    }
}

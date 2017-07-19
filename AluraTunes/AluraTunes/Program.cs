using AluraTunes.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZXing;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteId = 17;
            using (var contexto = new AluraTunesEntities())
            {
                var query = from v in contexto.ps_Itens_Por_Cliente(clienteId)//Utilizando StoredProcedure como fonte de dados
                            group v by new//Agrupando por campos anônimos
                            {
                                v.DataNotaFiscal.Year,
                                v.DataNotaFiscal.Month
                            }
                                into Agrupado//Adicionando o valor do agrupamentoa uma variável
                                orderby Agrupado.Key.Year, Agrupado.Key.Month//Ordenando o agrupamento
                                select new//Criando objeto anônimo com o resultado esperado.
                                {
                                    Mes = Agrupado.Key.Month,
                                    Ano = Agrupado.Key.Year,
                                    Total = Agrupado.Sum(x => x.Total)

                                };
                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.Ano, item.Mes, item.Total);
                }
            }      
            Console.ReadKey();
        }
    }
}

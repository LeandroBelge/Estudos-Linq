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
                var maiorVenda = contexto.NotaFiscals.Max(nf => nf.Total);
                var menorVenda = contexto.NotaFiscals.Min(nf => nf.Total);
                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);

                Console.WriteLine("A maior venda é de R$: " + maiorVenda);
                Console.WriteLine("A menor venda é de R$: " + menorVenda);
                Console.WriteLine("A venda média é de R$: " + vendaMedia);
            }
            Console.ReadKey();
        }
    }
}

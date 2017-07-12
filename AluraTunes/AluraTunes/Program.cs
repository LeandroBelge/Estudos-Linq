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
            const int TAMANHO_PAGINA = 10;

            using (var contexto = new AluraTunesEntities())
            {
                var numeroNotasFiscais = contexto.NotaFiscals.Count();

                var numeroPaginas = Math.Ceiling(Convert.ToDecimal(numeroNotasFiscais / TAMANHO_PAGINA));

                for (int i = 1; i <= numeroPaginas; i++)
                {
                    ImprimirPagina(TAMANHO_PAGINA, contexto, i);   
                }
                Console.ReadKey();
            }
        }

        private static void ImprimirPagina(int TAMANHO_PAGINA, AluraTunesEntities contexto, int numeroPagina)
        {
            var query =
                from nf in contexto.NotaFiscals
                orderby nf.NotaFiscalId
                select new
                {
                    Numero = nf.NotaFiscalId,
                    Data = nf.DataNotaFiscal,
                    Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                    Total = nf.Total

                };


            int numeroDePulos = (numeroPagina - 1) * TAMANHO_PAGINA;

            query = query.Skip(numeroDePulos);//Pular n linhas do resultado

            query = query.Take(TAMANHO_PAGINA);//Pegar n linhas de resultado

            Console.WriteLine("Número da página: {0}", numeroPagina);

            foreach (var nf in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", nf.Numero, nf.Data, nf.Cliente, nf.Total);
            }
        }
    }
}

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

                var faixasQuery =
                    from f in contexto.Faixas
                    where f.ItemNotaFiscals.Count() > 0 //Filtro para pegar apenas itens de nota fiscal com alguma informação.
                    let TotalDeVendas = f.ItemNotaFiscals.Sum(i => (i.Quantidade * i.PrecoUnitario))//Variável interna da consulta com projeção de um objeto
                    orderby TotalDeVendas descending
                    select new { 
                        f.FaixaId,
                        f.Nome,
                        Total = TotalDeVendas
                    };

                var ProdutoMaisVendido = faixasQuery.First();
		        Console.WriteLine("{0}\t{1}\t{2}", ProdutoMaisVendido.FaixaId, ProdutoMaisVendido.Nome, ProdutoMaisVendido.Total);
                
                //Recuperar quais clientes compraram a faixa de maior venda.
                var query =
                    from inf in contexto.ItemNotaFiscals
                    where inf.FaixaId == ProdutoMaisVendido.FaixaId
                    select new
                    {
                        NomeCliente = inf.NotaFiscal.Cliente.PrimeiroNome + " " + inf.NotaFiscal.Cliente.Sobrenome
                    };
                foreach (var cliente in query)
                {
                    Console.WriteLine(cliente.NomeCliente);
                }
            }
            Console.ReadKey();
        }

    }
}

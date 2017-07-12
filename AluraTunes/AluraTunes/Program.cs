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
            var nomeDaMusica = "Smells Like Teen Spirit";
            using (var contexto = new AluraTunesEntities())
            {
                var faixaIds = contexto.Faixas.Where(f => f.Nome == nomeDaMusica).Select(f => f.FaixaId);
                
                var query =
                    from comprouItem in contexto.ItemNotaFiscals
                    join comprouTambem in contexto.ItemNotaFiscals
                        on comprouItem.NotaFiscalId equals comprouTambem.NotaFiscalId
                    where faixaIds.Contains(comprouItem.FaixaId)
                    && comprouItem.FaixaId != comprouTambem.FaixaId
                    select comprouTambem;

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}",  item.NotaFiscalId, item.Faixa.Nome);
                }
            }
            Console.ReadKey();
        }

    }
}

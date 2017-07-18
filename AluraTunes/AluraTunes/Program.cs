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
        //Como gerar códigos QRCode utilizando ZXing.Net
        private const string IMAGENS = "Imagens";
        static void Main(string[] args)
        {
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 100,
                Height = 100
            };
            if (!Directory.Exists(IMAGENS))
            {
                Directory.CreateDirectory(IMAGENS);
            }
            using (var contexto = new AluraTunesEntities())
            {
                var listaFaixas = (from f in contexto.Faixas
                                  select f).ToList();

                Stopwatch stopwatch = Stopwatch.StartNew();

                var queryCodigos = listaFaixas.AsParallel()//Parelelizando a consulta para otimizar o tempo de consulta.
                    .Select(f => new { 
                    Arquivo = string.Format("{0}\\{1}.jpg", IMAGENS, f.FaixaId),
                    Imagem = barcodeWriter.Write(string.Format("aluratunes.com/faixa/{0}", f.FaixaId))
                });

                var contagem = queryCodigos.Count();
                stopwatch.Stop();

                Console.WriteLine("Códigos gerados: {0} em {1} segundos", contagem, stopwatch.ElapsedMilliseconds/1000.0);

                stopwatch = Stopwatch.StartNew();
                
                queryCodigos.ForAll(item => item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg));//Paralelizando a persistencia do código em arquivo. Isso otimiza o tempo de execução da aplicação.

                stopwatch.Stop();
                Console.WriteLine("Códigos salvos: {0} em {1} segundos", contagem, stopwatch.ElapsedMilliseconds / 1000.0);
            }
            Console.ReadKey();
        }
    }
}

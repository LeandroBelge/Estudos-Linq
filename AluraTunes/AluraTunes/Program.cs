using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listar todos os gêneros rock
            var generos = new List<Genero>
            {
                new Genero {Id = 1, Nome = "Rock"},
                new Genero {Id = 2, Nome = "Reggae"},
                new Genero {Id = 3, Nome = "Rock Progressivo"},
                new Genero {Id = 4, Nome = "Punk Rock"},
                new Genero {Id = 5, Nome = "Clássica"}
            };

          
            var query = from g in generos where g.Nome.Contains("Rock") select g;
            foreach (var genero in query)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }

            Console.WriteLine();

            //Listar músicas
            var musicas = new List<Musica>
            {
                new Musica {Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1},
                new Musica {Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2},
                new Musica {Id = 1, Nome = "Danúbio Azul", GeneroId = 5}
            };

            var musicaQuery = from m in musicas
                              join g in generos on m.GeneroId equals g.Id
                              where g.Nome.Equals("Reggae")
                              select new { m, g};

            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
            }

            Console.WriteLine();

            List<Atleta> atletas = new List<Atleta>()
                {
                    new Atleta { Posicao = 1, CodigoPais = "JAM", Nome = "BOLT Usain", Tempo = 9.81f },
                    new Atleta { Posicao = 2, CodigoPais = "USA", Nome = "GATLIN Justin", Tempo = 9.89f },
                    new Atleta { Posicao = 3, CodigoPais = "CAN", Nome = "DE GRASSE Andre", Tempo = 9.91f },
                    new Atleta { Posicao = 4, CodigoPais = "JAM", Nome = "BLAKE Yohan", Tempo = 9.93f },
                    new Atleta { Posicao = 5, CodigoPais = "RSA", Nome = "SIMBINE Akani", Tempo = 9.94f },
                    new Atleta { Posicao = 6, CodigoPais = "CIV", Nome = "MEITE Ben Youssef", Tempo = 9.96f },
                    new Atleta { Posicao = 7, CodigoPais = "FRA", Nome = "VICAUT Jimmy", Tempo = 10.04f },
                    new Atleta { Posicao = 8, CodigoPais = "USA", Nome = "BROMELL Trayvon", Tempo = 10.06f }
                };

            var atletaQuery = from a in atletas
                              where a.CodigoPais.Contains("JAM")
                              select a;

            foreach (var item in atletaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.Posicao, item.CodigoPais, item.Nome, item.Tempo);
            }

            Console.ReadKey();
        }
    }

    class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }

    class Atleta
    {
        public int Posicao { get; set; }
        public string CodigoPais { get; set; }
        public string Nome { get; set; }
        public double Tempo { get; set; }
    }
}

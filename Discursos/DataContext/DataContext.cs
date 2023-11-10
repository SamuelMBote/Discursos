using Discursos.Entities;
using Discursos.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Discursos.DataContext
{
    public class DatabaseContext : DbContext


    {
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Congregacao> Congregacoes { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Orador> Oradores { get; set; }
        public DbSet<Programacao> Programacoes { get; set; }
        
        public DbSet<Designacao> Designacoes { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Discursos;User ID=sa;Password=Scnet555;TrustServerCertificate=True;Trusted_Connection=True;", p => p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null).MigrationsHistoryTable("Discursos_Migration_Version"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            MapearPropriedadesEsquecidas(modelBuilder);
            PreencherTabelaTipoCongregacao(modelBuilder);
            PreencherTabelaDesignacoes(modelBuilder);
            PreencherTabelaTemas(modelBuilder);
        }

        private static void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));
                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        //property.SetMaxLength(255);
                        property.SetColumnType("NVARCHAR(255)");
                    }
                }
            }
        }

        private static void PreencherTabelaTipoCongregacao(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tipo>().HasData(
                new Tipo()
                {
                    Id = 1,
                    Codigo = ETipoCongregacao.Grupo,
                    Descricao = "Grupo"

                },
                new Tipo()
                {
                    Id = 2,
                    Codigo = ETipoCongregacao.GrupoIsolado,
                    Descricao = "Grupo Isolado"
                },

                new Tipo()
                {
                    Id = 3,
                    Codigo = ETipoCongregacao.Congregacao,
                    Descricao = "Congregação"
                }
                );

        }

        private static void PreencherTabelaDesignacoes(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Designacao>().HasData(
                new Designacao()
                {
                    Id = 1,
                    Codigo = EDesignacao.ServoMinisterial,
                    Descricao = "Servo Ministerial"

                },
                new Designacao()
                {
                    Id = 2,
                    Codigo = EDesignacao.Anciao,
                    Descricao = "Ancião"
                },

                new Designacao()
                {
                    Id = 3,
                    Codigo = EDesignacao.PioneiroEspecial,
                    Descricao = "Pioneiro Especial"
                },

                 new Designacao()
                 {
                     Id = 4,
                     Codigo = EDesignacao.SuperintendentedeCircuito,
                     Descricao = "Superintendente de Circuito"
                 },
                  new Designacao()
                  {
                      Id = 5,
                      Codigo = EDesignacao.EventoEspecial,
                      Descricao = "Evento Especial"
                  }
                );

        }

        private static void PreencherTabelaTemas(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Tema>().HasData(
              new Tema()
              {
                  Id = 1,
                  Numero = 1,
                  Descricao = "Você conhece bem a Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 2,
                  Numero = 2,
                  Descricao = "Você vai sobreviver aos últimos dias?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
                 {
                     Id = 3,
                     Numero = 3,
                     Descricao = "Você está avançando com a organização unida de Jeová?",
                     DuracaoEmMinutos = 30,
                     AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                     Id = 4,
                     Numero = 4,
                     Descricao = "Que provas temos de que Deus existe?",
                     DuracaoEmMinutos = 30,
                     AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 5,
                  Numero = 5,
                  Descricao = "Você pode ter uma família feliz!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 6,
                  Numero = 6,
                  Descricao = "O dilúvio dos dias de Noé e você",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 7,
                  Numero = 7,
                  Descricao = "Imite a misericórdia de Jeová",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 12, 1)
              },
              new Tema()
              {
                  Id = 8,
                  Numero = 8,
                  Descricao = "Viva para fazer a vontade de Deus",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 9,
                  Numero = 9,
                  Descricao = "Escute e faça o que a Bíblia diz",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 10,
                  Numero = 10,
                  Descricao = "Seja honesto em tudo",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 11,
                  Numero = 11,
                  Descricao = "Imite a Jesus e não faça parte do mundo",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 12,
                  Numero = 12,
                  Descricao = "Deus quer que você respeite quem tem autoridade",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 13,
                  Numero = 13,
                  Descricao = "Qual o ponto de vista de Deus sobre o sexo e o casamento?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 14,
                  Numero = 14,
                  Descricao = "Um povo puro e limpo honra a Jeová",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 10, 1)
              },
              new Tema()
              {
                  Id = 15,
                  Numero = 15,
                  Descricao = "‘Faça o bem a todos’",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 16,
                  Numero = 16,
                  Descricao = "Seja cada vez mais amigo de Jeová",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 12, 1)
              },
              new Tema()
              {
                  Id = 17,
                  Numero = 17,
                  Descricao = "Glorifique a Deus com tudo o que você tem",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 4, 1)
              },
              new Tema()
              {
                  Id = 18,
                  Numero = 18,
                  Descricao = "Faça de Jeová a sua fortaleza",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 4, 1)
              },
              new Tema()
              {
                  Id = 19,
                  Numero = 19,
                  Descricao = "Como você pode saber seu futuro?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 20,
                  Numero = 20,
                  Descricao = "Chegou o tempo de Deus governar o mundo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 7, 1)
              },
              new Tema()
              {
                  Id = 21,
                  Numero = 21,
                  Descricao = "Dê valor ao seu lugar no Reino de Deus",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 4, 1)
              },
              new Tema()
              {
                  Id = 22,
                  Numero = 22,
                  Descricao = "Você está usando bem o que Jeová lhe dá?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 4, 1)
              },
              new Tema()
              {
                  Id = 23,
                  Numero = 23,
                  Descricao = "A vida tem objetivo",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 6, 1)
              },
              new Tema()
              {
                  Id = 24,
                  Numero = 24,
                  Descricao = "Você encontrou “uma pérola de grande valor”?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 8, 1)
              },
              new Tema()
              {
                  Id = 25,
                  Numero = 25,
                  Descricao = "Lute contra o espírito do mundo",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 10, 1)
              },
              new Tema()
              {
                  Id = 26,
                  Numero = 26,
                  Descricao = "Você é importante para Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 10, 1)
              },
              new Tema()
              {
                  Id = 27,
                  Numero = 27,
                  Descricao = "Como construir um casamento feliz",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 28,
                  Numero = 28,
                  Descricao = "Mostre respeito e amor no seu casamento",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 5, 1)
              },
              new Tema()
              {
                  Id = 29,
                  Numero = 29,
                  Descricao = "As responsabilidades e recompensas de ter filhos",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 5, 1)
              },
              new Tema()
              {
                  Id = 30,
                  Numero = 30,
                  Descricao = "Como melhorar a comunicação na família",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 31,
                  Numero = 31,
                  Descricao = "Você Tem Consciência Da Sua Necessidade Espiritual?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 8, 1)
              },
              new Tema()
              {
                  Id = 32,
                  Numero = 32,
                  Descricao = "Como lidar com as ansiedades da vida",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 33,
                  Numero = 33,
                  Descricao = "Quando vai existir verdadeira justiça?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 34,
                  Numero = 34,
                  Descricao = "Você vai ser marcado para sobreviver?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 35,
                  Numero = 35,
                  Descricao = "É possível viver para sempre? O que você precisa fazer?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 5, 1)
              },
              new Tema()
              {
                  Id = 36,
                  Numero = 36,
                  Descricao = "Será que a vida é só isso?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 5, 1)
              },
              new Tema()
              {
                  Id = 37,
                  Numero = 37,
                  Descricao = "Obedecer a Deus é mesmo a melhor coisa a fazer?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2017, 3, 1)
              },
              new Tema()
              {
                  Id = 38,
                  Numero = 38,
                  Descricao = "Como você pode sobreviver ao fim do mundo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2019, 11, 1)
              },
              new Tema()
              {
                  Id = 39,
                  Numero = 39,
                  Descricao = "Como você pode sobreviver ao fim do mundo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 40,
                  Numero = 40,
                  Descricao = "O que vai acontecer em breve?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 10, 1)
              },
              new Tema()
              {
                  Id = 41,
                  Numero = 41,
                  Descricao = "Fiquem parados e vejam como Jeová os salvará",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 11, 1)
              },
              new Tema()
              {
                  Id = 42,
                  Numero = 42,
                  Descricao = "O efeito do Reino de Deus sobre você",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1996, 1, 1)
              },
              new Tema()
              {
                  Id = 43,
                  Numero = 43,
                  Descricao = "Tudo o que Deus nos pede é para o nosso bem",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 44,
                  Numero = 44,
                  Descricao = "Como os ensinos de Jesus podem ajudar você?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 5, 1)
              },
              new Tema()
              {
                  Id = 45,
                  Numero = 45,
                  Descricao = "Continue andando no caminho que leva à vida",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 46,
                  Numero = 46,
                  Descricao = "Fortaleça sua confiança em Jeová",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 47,
                  Numero = 47,
                  Descricao = "‘Tenha fé nas boas novas’",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 9, 1)
              },
              new Tema()
              {
                  Id = 48,
                  Numero = 48,
                  Descricao = "Seja leal a Deus mesmo quando for testado",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 49,
                  Numero = 49,
                  Descricao = "Será que um dia a Terra vai ser limpa?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 50,
                  Numero = 50,
                  Descricao = "Como sempre tomar as melhores decisões",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                Id = 51,
                Numero = 51,
                Descricao = "Será que a verdade da Bíblia está mudando a sua vida?",
                DuracaoEmMinutos = 30,
                AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 51,
                  Numero = 51,
                  Descricao = "Será que a verdade da Bíblia está mudando a sua vida?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 52,
                  Numero = 52,
                  Descricao = "Quem é o seu Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 53,
                  Numero = 53,
                  Descricao = "Você pensa como Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 9, 1)
              },
              new Tema()
              {
                  Id = 54,
                  Numero = 54,
                  Descricao = "Fortaleça sua fé em Deus e em suas promessas",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 5, 1)
              },
              new Tema()
              {
                  Id = 55,
                  Numero = 55,
                  Descricao = "Você está fazendo um bom nome perante Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 5, 1)
              },
              new Tema()
              {
                  Id = 56,
                  Numero = 56,
                  Descricao = "Existe um líder em quem você pode confiar?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2019, 9, 1)
              },
              new Tema()
              {
                  Id = 57,
                  Numero = 57,
                  Descricao = "Como suportar perseguição",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 58,
                  Numero = 58,
                  Descricao = "Quem são os verdadeiros seguidores de Cristo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2017, 11, 1)
              },
              new Tema()
              {
                  Id = 59,
                  Numero = 59,
                  Descricao = "Ceifará o que semear",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 60,
                  Numero = 60,
                  Descricao = "Você tem um objetivo na vida?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 9, 1)
              },
              new Tema()
              {
                  Id = 61,
                  Numero = 61,
                  Descricao = "Nas promessas de quem você confia?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 9, 1)
              },
              new Tema()
              {
                  Id = 62,
                  Numero = 62,
                  Descricao = "Onde encontrar uma esperança real para o futuro?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 63,
                  Numero = 63,
                  Descricao = "Tem você espírito evangelizador?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 63,
                  Numero = 63,
                  Descricao = "Tem você espírito evangelizador?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 64,
                  Numero = 64,
                  Descricao = "Você ama os prazeres ou a Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 5, 1)
              },
              new Tema()
              {
                  Id = 65,
                  Numero = 65,
                  Descricao = "Como podemos ser pacíficos num mundo cheio de ódio",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 7, 1)
              },
              new Tema()
              {
                  Id = 66,
                  Numero = 66,
                  Descricao = "Você também vai participar na colheita?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 6, 1)
              },
              new Tema()
              {
                  Id = 67,
                  Numero = 67,
                  Descricao = "Medite na Bíblia e nas criações de Jeová",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 6, 1)
              },
              new Tema()
              {
                  Id = 68,
                  Numero = 68,
                  Descricao = "‘Continuem a perdoar uns aos outros liberalmente’",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 69,
                  Numero = 69,
                  Descricao = "Por que mostrar amor abnegado?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 6, 1)
              },
              new Tema()
              {
                  Id = 70,
                  Numero = 70,
                  Descricao = "Faça de Jeová a sua confiança",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 71,
                  Numero = 71,
                  Descricao = "‘Mantenha-se desperto’ — Por que e como?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 6, 1)
              },
              new Tema()
              {
                  Id = 72,
                  Numero = 72,
                  Descricao = "O amor identifica os cristãos verdadeiros",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 6, 1)
              },
              new Tema()
              {
                  Id = 73,
                  Numero = 73,
                  Descricao = "Você tem “um coração sábio”?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 5, 1)
              },
              new Tema()
              {
                  Id = 74,
                  Numero = 74,
                  Descricao = "Os olhos de Jeová estão em todo lugar",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 9, 1)
              },
              new Tema()
              {
                  Id = 75,
                  Numero = 75,
                  Descricao = "Mostre que você apoia o direito de Jeová governar",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 9, 1)
              },
              new Tema()
              {
                  Id = 76,
                  Numero = 76,
                  Descricao = "Princípios bíblicos — Podem nos ajudar a lidar com os problemas atuais?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 77,
                  Numero = 77,
                  Descricao = "“Sempre mostrem hospitalidade”",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 11, 1)
              },
              new Tema()
              {
                  Id = 78,
                  Numero = 78,
                  Descricao = "Sirva a Jeová com um coração alegre",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 11, 1)
              },
              new Tema()
              {
                  Id = 79,
                  Numero = 79,
                  Descricao = "Você vai escolher ser amigo de Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 11, 1)
              },
              new Tema()
              {
                  Id = 80,
                  Numero = 80,
                  Descricao = "Você baseia sua esperança na ciência ou na Bíblia?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 11, 1)
              },
              new Tema()
              {
                  Id = 81,
                  Numero = 81,
                  Descricao = "Quem está qualificado para fazer discípulos?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 11, 1)
              },
              new Tema()
              {
                  Id = 82,
                  Numero = 82,
                  Descricao = "Jeová e Cristo fazem parte de uma trindade?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 5, 1)
              },
              new Tema()
              {
                  Id = 83,
                  Numero = 83,
                  Descricao = "Tempo de julgamento da religião",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 11, 1)
              },
              new Tema()
              {
                  Id = 84,
                  Numero = 84,
                  Descricao = "Escapará do destino deste mundo?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2003, 11, 1)
              },
              new Tema()
              {
                  Id = 85,
                  Numero = 85,
                  Descricao = "Boas notícias num mundo violento",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2001, 9, 1)
              },
              new Tema()
              {
                  Id = 86,
                  Numero = 86,
                  Descricao = "Como orar a Deus e ser ouvido por ele?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 5, 1)
              },
              new Tema()
              {
                  Id = 87,
                  Numero = 87,
                  Descricao = "Qual é a sua relação com Deus?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 1, 1)
              },
              new Tema()
              {
                  Id = 88,
                  Numero = 88,
                  Descricao = "Por que viver de acordo com os padrões da Bíblia?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 5, 1)
              },
              new Tema()
              {
                  Id = 89,
                  Numero = 89,
                  Descricao = "Quem tem sede da verdade, venha!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 5, 1)
              },
              new Tema()
              {
                  Id = 90,
                  Numero = 90,
                  Descricao = "Faça o máximo para alcançar a verdadeira vida!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 8, 1)
              },
              new Tema()
              {
                  Id = 91,
                  Numero = 91,
                  Descricao = "A presença do Messias e seu domínio",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 11, 1)
              },
              new Tema()
              {
                  Id = 92,
                  Numero = 92,
                  Descricao = "O papel da religião nos assuntos do mundo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 11, 1)
              },
              new Tema()
              {
                  Id = 93,
                  Numero = 93,
                  Descricao = "Desastres naturais — Quando vão acabar?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 94,
                  Numero = 94,
                  Descricao = "A religião verdadeira atende às necessidades da sociedade humana",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1993, 12, 1)
              },
              new Tema()
              {
                  Id = 95,
                  Numero = 95,
                  Descricao = "Não seja enganado pelo ocultismo!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 96,
                  Numero = 96,
                  Descricao = "O QUE VAI ACONTECER COM AS RELIGIÕES?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2019, 5, 1)
              },
              new Tema()
              {
                  Id = 97,
                  Numero = 97,
                  Descricao = "Permaneçamos inculpes em meio a uma geração pervertida",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1996, 1, 1)
              },
              new Tema()
              {
                  Id = 98,
                  Numero = 98,
                  Descricao = "“A cena deste mundo está mudando”",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 9, 1)
              },
              new Tema()
              {
                  Id = 99,
                  Numero = 99,
                  Descricao = "Por que você pode confiar na Bíblia",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 9, 1)
              },
              new Tema()
              {
                  Id = 100,
                  Numero = 100,
                  Descricao = "Como fazer amizades fortes e verdadeiras",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 101,
                  Numero = 101,
                  Descricao = "Jeová é o “Grandioso Criador”",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 9, 1)
              },
              new Tema()
              {
                  Id = 102,
                  Numero = 102,
                  Descricao = "Preste atenção à “palavra profética”",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2023, 1, 1)
              },
              new Tema()
              {
                  Id = 103,
                  Numero = 103,
                  Descricao = "Pode-se encontrar alegria em servir a Deus",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1999, 2, 1)
              },
              new Tema()
              {
                  Id = 104,
                  Numero = 104,
                  Descricao = "Pais, vocês estão construindo com materiais à prova de fogo?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2023, 1, 1)

              },
              new Tema()
              {
                  Id = 105,
                  Numero = 105,
                  Descricao = "Somos consolados em todas as nossas tribulações",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 5, 1)
              },
              new Tema()
              {
                  Id = 106,
                  Numero = 106,
                  Descricao = "Arruinar a terra provocará retribuição divina",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 5, 1)
              },
              new Tema()
              {
                  Id = 107,
                  Numero = 107,
                  Descricao = "Você está treinando bem a sua consciência?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2023, 1, 1)
              },
              new Tema()
              {
                  Id = 108,
                  Numero = 108,
                  Descricao = "Vença o medo do futuro",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 5, 1)
              },
              new Tema()
              {
                  Id = 109,
                  Numero = 109,
                  Descricao = "O Reino de Deus está próximo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1996, 1, 1)
              },
              new Tema()
              {
                  Id = 110,
                  Numero = 110,
                  Descricao = "Deus vem primeiro na vida familiar bem-sucedida",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 1, 1)
              },
              new Tema()
              {
                  Id = 111,
                  Numero = 111,
                  Descricao = "É possível que a humanidade seja completamente curada?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2023, 1, 1)
              },
              new Tema()
              {
                  Id = 112,
                  Numero = 112,
                  Descricao = "Como expressar amor num mundo que viola a lei",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 1, 1)
              },
              new Tema()
              {
                  Id = 113,
                  Numero = 113,
                  Descricao = "Jovens — Como vocês podem ter uma vida feliz?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2020, 1, 1)
              },
              new Tema()
              {
                  Id = 114,
                  Numero = 114,
                  Descricao = "Apreço pelas maravilhas da criação de Deus",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 1, 1)
              },
              new Tema()
              {
                  Id = 115,
                  Numero = 115,
                  Descricao = "Como proteger-nos contra os laços de Satanás",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1995, 4, 1)
              },
              new Tema()
              {
                  Id = 116,
                  Numero = 116,
                  Descricao = "Escolha sabiamente com quem irá associar-se!",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2007, 9, 1)
              },
              new Tema()
              {
                  Id = 117,
                  Numero = 117,
                  Descricao = "Como vencer o mal com o bem",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2006, 11, 1)
              },
              new Tema()
              {
                  Id = 118,
                  Numero = 118,
                  Descricao = "Olhemos os jovens do ponto de vista de Jeová",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1998, 8, 1)
              },
              new Tema()
              {
                  Id = 119,
                  Numero = 119,
                  Descricao = "Por que é benéfico que os cristãos vivam separados do mundo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 5, 1)
              },
              new Tema()
              {
                  Id = 120,
                  Numero = 120,
                  Descricao = "Por que se submeter à regência de Deus agora",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 6, 1)
              },
              new Tema()
              {
                  Id = 121,
                  Numero = 121,
                  Descricao = "Uma família mundial que será salva da destruição",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2021, 9, 1)
              },
              new Tema()
              {
                  Id = 122,
                  Numero = 122,
                  Descricao = "Paz global — de onde virá?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 7, 1)
              },
              new Tema()
              {
                  Id = 123,
                  Numero = 123,
                  Descricao = "Por que os cristãos têm de ser diferentes",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 6, 1)
              },
              new Tema()
              {
                  Id = 124,
                  Numero = 124,
                  Descricao = "Razões para crer que a Bíblia é de autoria divina",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1997, 6, 1)
              },
              new Tema()
              {
                  Id = 125,
                  Numero = 125,
                  Descricao = "Por que a humanidade precisa de resgate",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(1999, 10, 1)
              },
              new Tema()
              {
                  Id = 126,
                  Numero = 126,
                  Descricao = "Quem se salvará?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2000, 11, 1)
              },
              new Tema()
              {
                  Id = 127,
                  Numero = 127,
                  Descricao = "O que acontece quando morremos?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2000, 8, 1)
              },
              new Tema()
              {
                  Id = 128,
                  Numero = 128,
                  Descricao = "É o inferno um lugar de tormento ardente?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2000, 11, 1)
              },
              new Tema()
              {
                  Id = 129,
                  Numero = 129,
                  Descricao = "O que a Bíblia diz sobre a Trindade?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2022, 5, 1)
              },
              new Tema()
              {
                  Id = 130,
                  Numero = 130,
                  Descricao = "A terra permanecerá para sempre",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 131,
                  Numero = 131,
                  Descricao = "Será que o Diabo realmente existe?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 132,
                  Numero = 132,
                  Descricao = "Ressurreição — a vitória sobre a morte!",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 133,
                  Numero = 133,
                  Descricao = "Tem importância o que cremos sobre a nossa origem?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 134,
                  Numero = 134,
                  Descricao = "Devem os cristãos guardar o sábado?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 135,
                  Numero = 135,
                  Descricao = "A santidade da vida e do sangue",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 136,
                  Numero = 136,
                  Descricao = "Será que Deus aprova o uso de imagens na adoração?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 137,
                  Numero = 137,
                  Descricao = "Ocorreram realmente os milagres da Bíblia?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 138,
                  Numero = 138,
                  Descricao = "Viva com bom juízo num mundo depravado",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 139,
                  Numero = 139,
                  Descricao = "Sabedoria divina num mundo científico",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 140,
                  Numero = 140,
                  Descricao = "Quem é realmente Jesus Cristo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 8, 1)
              },
              new Tema()
              {
                  Id = 141,
                  Numero = 141,
                  Descricao = "Quando terão fim os gemidos da criação humana?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 142,
                  Numero = 142,
                  Descricao = "Por que refugiar-se em Jeová",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 143,
                  Numero = 143,
                  Descricao = "Confie no Deus de todo consolo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 144,
                  Numero = 144,
                  Descricao = "Uma congregação leal sob a liderança de Cristo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 145,
                  Numero = 145,
                  Descricao = "Quem é semelhante a Jeová, nosso Deus?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 146,
                  Numero = 146,
                  Descricao = "Use a educação para louvar a Jeová",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 147,
                  Numero = 147,
                  Descricao = "Confie no poder salvador de Jeová",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 148,
                  Numero = 148,
                  Descricao = "Você tem o mesmo conceito de Deus sobre a vida?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 149,
                  Numero = 149,
                  Descricao = "O que significa “andar com Deus”?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 150,
                  Numero = 150,
                  Descricao = "Este mundo está condenado à destruição?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2018, 3, 1)
              },
              new Tema()
              {
                  Id = 151,
                  Numero = 151,
                  Descricao = "Jeová é “uma altura protetora” para seu povo",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2000, 11, 1)
              },
              new Tema()
              {
                  Id = 152,
                  Numero = 152,
                  Descricao = "Armagedom — por que e quando?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2001, 10, 1)
              },
              new Tema()
              {
                  Id = 153,
                  Numero = 153,
                  Descricao = "Tenha bem em mente o “atemorizante dia”!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2019, 8, 1)
              },
              new Tema()
              {
                  Id = 154,
                  Numero = 154,
                  Descricao = "O governo humano é pesado na balança",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2002, 3, 1)
              },
              new Tema()
              {
                  Id = 155,
                  Numero = 155,
                  Descricao = "Chegou a hora do julgamento de Babilônia?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2002, 12, 1)
              },
              new Tema()
              {
                  Id = 156,
                  Numero = 156,
                  Descricao = "O Dia do Juízo — tempo de temor ou de esperança?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2003, 6, 1)
              },
              new Tema()
              {
                  Id = 157,
                  Numero = 157,
                  Descricao = "Como os verdadeiros cristãos adornam o ensino divino",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2003, 5, 1)
              },
              new Tema()
              {
                  Id = 158,
                  Numero = 158,
                  Descricao = "Seja corajoso e confie em Jeová",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2003, 11, 1)
              },
              new Tema()
              {
                  Id = 159,
                  Numero = 159,
                  Descricao = "Como encontrar segurança num mundo perigoso",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2003, 15, 1)
              },
              new Tema()
              {
                  Id = 160,
                  Numero = 160,
                  Descricao = "Mantenha a identidade cristã!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2011, 11, 1)
              },
              new Tema()
              {
                  Id = 161,
                  Numero = 161,
                  Descricao = "Por que Jesus sofreu e morreu?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2004, 12, 1)
              },
              new Tema()
              {
                  Id = 162,
                  Numero = 162,
                  Descricao = "Seja liberto deste mundo em escuridão",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2014, 11, 1)
              },
              new Tema()
              {
                  Id = 163,
                  Numero = 163,
                  Descricao = "Por que temer o Deus verdadeiro?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 164,
                  Numero = 164,
                  Descricao = "Será que Deus ainda está no controle?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2005, 11, 1)
              },
              new Tema()
              {
                  Id = 165,
                  Numero = 165,
                  Descricao = "Os valores de quem você preza?",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2005, 11, 1)
              },
              new Tema()
              {
                  Id = 166,
                  Numero = 166,
                  Descricao = "Como enfrentar o futuro com fé e coragem",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2006, 5, 1)
              },
              new Tema()
              {
                  Id = 167,
                  Numero = 167,
                  Descricao = "Ajamos sabiamente num mundo insensato",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2006, 12, 1)
              },
              new Tema()
              {
                  Id = 168,
                  Numero = 168,
                  Descricao = "Você pode sentir-se seguro neste mundo atribulado!",
                  DuracaoEmMinutos = 45,
                  AtualizadoEm = new DateTime(2006, 11, 1)
              },
              new Tema()
              {
                  Id = 169,
                  Numero = 169,
                  Descricao = "Por que ser orientado pela Bíblia?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2006, 11, 1)
              },
              new Tema()
              {
                  Id = 170,
                  Numero = 170,
                  Descricao = "Quem está qualificado para governar a humanidade?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2007, 12, 1)
              },
              new Tema()
              {
                  Id = 171,
                  Numero = 171,
                  Descricao = "Poderá viver em paz agora — e para sempre!",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(208, 1, 1)
              },
              new Tema()
              {
                  Id = 172,
                  Numero = 172,
                  Descricao = "Que reputação você tem perante Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2008, 5, 1)
              },
              new Tema()
              {
                  Id = 173,
                  Numero = 173,
                  Descricao = "Existe uma religião verdadeira do ponto de vista de Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2008, 9, 1)
              },
              new Tema()
              {
                  Id = 174,
                  Numero = 174,
                  Descricao = "Quem se qualificará para entrar no novo mundo de Deus?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2008, 11, 1)
              },
              new Tema()
              {
                  Id = 175,
                  Numero = 175,
                  Descricao = "O que prova que a Bíblia é autêntica ?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2009, 8, 1)
              },
              new Tema()
              {
                  Id = 176,
                  Numero = 176,
                  Descricao = "Quando haverá verdadeira paz e segurança?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2009, 9, 1)
              },
              new Tema()
              {
                  Id = 177,
                  Numero = 177,
                  Descricao = "Onde encontrar ajuda em tempos de aflição?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2010, 1, 1)
              },
              new Tema()
              {
                  Id = 178,
                  Numero = 178,
                  Descricao = "Ande no caminho da integridade",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2010, 6, 1)
              },
              new Tema()
              {
                  Id = 179,
                  Numero = 179,
                  Descricao = "Rejeite as fantasias do mundo, empenhe-se pelas realidades do reino",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2010, 11, 1)
              },
              new Tema()
              {
                  Id = 180,
                  Numero = 180,
                  Descricao = "A Ressurreição — Por que essa esperança deve ser real para você",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2011, 5, 1)
              },
              new Tema()
              {
                  Id = 181,
                  Numero = 181,
                  Descricao = "Já é mais tarde do que você imagina?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2011, 6, 1)
              },
              new Tema()
              {
                  Id = 182,
                  Numero = 182,
                  Descricao = "O que o Reino de Deus está fazendo por nós agora?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2011, 9, 1)
              },
              new Tema()
              {
                  Id = 183,
                  Numero = 183,
                  Descricao = "Desvie seus olhos do que é fútil",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 9, 1)
              },
              new Tema()
              {
                  Id = 184,
                  Numero = 184,
                  Descricao = "A morte é o fim de tudo?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2012, 7, 1)
              },
              new Tema()
              {
                  Id = 185,
                  Numero = 185,
                  Descricao = "Será que a verdade influencia sua vida?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2012, 11, 1)
              },
              new Tema()
              {
                  Id = 186,
                  Numero = 186,
                  Descricao = "Sirva em união com o povo feliz de Deus",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2013, 3, 1)
              },
              new Tema()
              {
                  Id = 187,
                  Numero = 187,
                  Descricao = "Por que um Deus amoroso permite a maldade?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2013, 7, 1)
              },
              new Tema()
              {
                  Id = 188,
                  Numero = 188,
                  Descricao = "Você confia em Jeová?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2014, 1, 1)
              },
              new Tema()
              {
                  Id = 189,
                  Numero = 189,
                  Descricao = "Ande com Deus e receba bênçãos para sempre",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2014, 4, 1)
              },
              new Tema()
              {
                  Id = 190,
                  Numero = 190,
                  Descricao = "Como se cumprirá a promessa de perfeita felicidade familiar",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2014, 7, 1)
              },
              new Tema()
              {
                  Id = 191,
                  Numero = 191,
                  Descricao = "Como o amor e a fé vencem o mundo",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 4, 1)
              },
              new Tema()
              {
                  Id = 192,
                  Numero = 192,
                  Descricao = "Você está no caminho para a vida eterna?",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 8, 1)
              },
              new Tema()
              {
                  Id = 193,
                  Numero = 193,
                  Descricao = "Os problemas de hoje logo serão coisa do passado",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2015, 11, 1)
              },
              new Tema()
              {
                  Id = 194,
                  Numero = 194,
                  Descricao = "Como a sabedoria de Deus nos ajuda",
                  DuracaoEmMinutos = 30,
                  AtualizadoEm = new DateTime(2016, 5, 1)
              }
        );
        
        }
    }
}

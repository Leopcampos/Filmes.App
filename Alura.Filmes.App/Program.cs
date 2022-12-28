using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //select * from actor
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var categ = "Action";

                var paramCateg = new SqlParameter("category_name", categ);

                var paramTotal = new SqlParameter
                {
                    ParameterName = "@total_actors",
                    Size = 4,
                    Direction = System.Data.ParameterDirection.Output
                };

                contexto.Database.ExecuteSqlCommand("execute total_actors_from_given_category @category_name, @total_actores OUT", paramCateg, paramTotal);

                Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}");

                //var sql = @"select a.* from actor a
                //            inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id";

                ////fromSql - executa uma view
                //var atoresMaisAtuantes = contexto.Atores
                //    .FromSql(sql)
                //    .Include(a => a.Filmografia);

                //foreach (var ator in atoresMaisAtuantes)
                //{
                //    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes;");
                //}
            }
        }
    }
}
using BreckProject1.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BreckProject1
{
    public class CommentRepository
    {
        private readonly string connectionString;

        public CommentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Comment> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Comment>("SELECT * FROM comment");
            }
        }

        public Comment GetById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Comment>("SELECT * FROM comment WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(Comment comment)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO comment (Text) VALUES (@Text)", comment);
            }
        }

        public void Update(Comment comment)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE comment SET Text = @Text WHERE Id = @Id", comment);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM comment WHERE Id = @Id", new { Id = id });
            }
        }
    }
}

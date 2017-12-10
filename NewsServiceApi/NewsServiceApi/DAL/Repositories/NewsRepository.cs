using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using NewsServiceApi.DAL.Models;

namespace NewsServiceApi.DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly string _connectinString;
        private readonly IConfiguration _configuration;

        private IDbConnection _connection
        {
            get { return new MySqlConnection(_connectinString); }
        }

        public NewsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectinString = _configuration["Data:ConnectionString:MySqlConnection"];
        }

        public async Task<News> GetByIdAsync(int id)
        {
            using(IDbConnection dbConnection = _connection)
            {
                string query = "SELECT * FROM news WHERE Id=@id";
                var news = await dbConnection.QueryFirstOrDefaultAsync<News>(query, new { id });
                return news;
            }
        }

       // public async Task<Category> Get

        //TODO: Think about paging
        public async Task<IEnumerable<News>> GetAllAsync()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = "SELECT * FROM news";
                var news = await dbConnection.QueryAsync<News>(query);
                return news;
            }
        }

        public async Task CreateAsync(News news)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO news (Heading, Body, Date, IdCategory)
                                            VALUES(@Heading, @Body, @Date, @IdCategory)";
                await dbConnection.ExecuteAsync(query, news);
            }
        }

        //TODO: I suppose I made wrong this method
        public async Task UpdateAsync(News news)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"UPDATE news
                                SET Heading=@Heading, Body=@Body, Date=@Date, IdCategory=@IdCategory
                                WHERE Id = @Id";
                await dbConnection.ExecuteAsync(query, news);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = "DELETE FROM news WHERE Id = @id";
                await dbConnection.ExecuteAsync(query, new { id });
            }
        }

    }
}

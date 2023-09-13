using Dapper;
using abv_api.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace abv_api.Repository
{
    public class GamesRepository
    {
        #region Injeção de Dependências
        private readonly IConfiguration _config;

        public GamesRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region GET
        public async Task<List<Games>> GetGames()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var query = "SELECT * FROM Games";
            var response = Instance.Query<Games>(query).ToList();
            return response;
        }
        #endregion
    }
}

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
    public class ReplacementRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public ReplacementRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region GET
        public async Task<List<Replacement>> GetReplacements()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); //instanciando a conexão
            var query = "SELECT * FROM Replacement";
            var response = Instance.Query<Replacement>(query).ToList();
            return response;
        }
        #endregion
    }
}

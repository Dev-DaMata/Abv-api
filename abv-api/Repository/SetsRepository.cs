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
    public class SetsRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public SetsRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region GET
        public async Task<List<Sets>> GetSets()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); //instanciando a conexão
            var query = "SELECT * FROM [Sets]";
            var response = Instance.Query<Sets>(query).ToList();
            return response;
        }
        #endregion

        #region GET POR ID
        public async Task<Sets> GetSet(int id_set)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_set", id_set, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM [Sets] WHERE id_set = @id_set";
            var response = await Instance.QueryFirstAsync<Sets>(query, param);
            return response;
        }
        #endregion
    }
}

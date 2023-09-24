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
    public class ClassificationRepository
    {
        #region Injeção de Dependências
        private readonly IConfiguration _config;

        public ClassificationRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region GET
        public async Task<List<Classification>> GetClassifications()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var query = "SELECT * FROM [Classification]";
            var response = Instance.Query<Classification>(query).ToList();
            return response;
        }
        #endregion

        #region GET POR ID 
        public async Task<Classification> GetClassification(int id_classification)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_classification", id_classification, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM [Classification] WHERE id_classification = @id_classification";
            var response = await Instance.QueryFirstAsync<Classification>(query, param);
            return response;
        }
        #endregion
    }
}

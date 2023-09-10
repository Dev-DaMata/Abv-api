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
    public class TeamRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public TeamRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region GET
        public async Task<List<Team>> GetTeams()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); //instanciando a conexão
            var query = "SELECT * FROM Team";
            var response = Instance.Query<Team>(query).ToList();
            return response;
        }
        #endregion

        #region GET POR ID
        public async Task<Team> GetTeam (int id_team)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_team", id_team, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM Team WHERE id_team = @id_team";
            var response = await Instance.QueryFirstAsync<Team>(query, param);
            return response;
        }
        #endregion
    }
}

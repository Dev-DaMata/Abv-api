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

        #region GET POR ID
        public async Task<Replacement> GetReplacement(int id_replacement)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_replacement", id_replacement, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM Replacement WHERE id_replacement = @id_replacement";
            var response = await Instance.QueryFirstAsync<Replacement>(query, param);
            return response;
        }
        #endregion

        #region POST 
        public async Task<bool> CreateReplacement(Replacement model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_team", model.id_team, direction: ParameterDirection.Input);
            param.Add("id_user_input", model.id_user_input, direction: ParameterDirection.Input);
            param.Add("id_user_exit", model.id_user_exit, direction: ParameterDirection.Input);
            param.Add("motivo", model.motivo, direction: ParameterDirection.Input);
            param.Add("scoreboard_replacement", model.scoreboard_replacement, direction: ParameterDirection.Input);
            param.Add("set", model.set, direction: ParameterDirection.Input);
            var query = @"INSERT INTO Replacement (id_team, id_user_input, id_user_exit, motivo, scoreboard_replacement, [set])
                        VALUES (@id_team, @id_user_input, @id_user_exit, @motivo, @scoreboard_replacement, @set)";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;

        }
        #endregion
    }
}

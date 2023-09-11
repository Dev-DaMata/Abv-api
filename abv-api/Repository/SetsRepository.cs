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

        #region POST 
        public async Task<bool> CreateSets(Sets model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
           
            var param = new DynamicParameters();
            param.Add("id_team1", model.id_team1, direction: ParameterDirection.Input);
            param.Add("id_team2", model.id_team2, direction: ParameterDirection.Input);
            param.Add("pts_team1", model.pts_team1, direction: ParameterDirection.Input);
            param.Add("pts_team2", model.pts_team2, direction: ParameterDirection.Input);
            param.Add("id_replacement_team1", model.id_replacement_team1, direction: ParameterDirection.Input);
            param.Add("id_replacement_team2", model.id_replacement_team2, direction: ParameterDirection.Input);
            param.Add("start_time", model.start_time, direction: ParameterDirection.Input);
            param.Add("end_time", model.end_time, direction: ParameterDirection.Input);
            param.Add("id_game", model.id_game, direction: ParameterDirection.Input);
            var query = @"INSERT INTO [Sets] (id_team1, id_team2, pts_team1, pts_team2, id_replacement_team1, id_replacement_team2, start_time, end_time, id_game)
                            VALUES (@id_team1, @id_team2, @pts_team1, @pts_team2, @id_replacement_team1, @id_replacement_team2, @start_time, @end_time, @id_game)";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;

        }
        #endregion

        #region PUT
        public async Task<bool> UpdateSets(Sets model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_set", model.id_set, direction: ParameterDirection.Input);
            param.Add("id_team1", model.id_team1, direction: ParameterDirection.Input);
            param.Add("id_team2", model.id_team2, direction: ParameterDirection.Input);
            param.Add("pts_team1", model.pts_team1, direction: ParameterDirection.Input);
            param.Add("pts_team2", model.pts_team2, direction: ParameterDirection.Input);
            param.Add("id_replacement_team1", model.id_replacement_team1, direction: ParameterDirection.Input);
            param.Add("id_replacement_team2", model.id_replacement_team2, direction: ParameterDirection.Input);
            param.Add("start_time", model.start_time, direction: ParameterDirection.Input);
            param.Add("end_time", model.end_time, direction: ParameterDirection.Input);
            param.Add("id_game", model.id_game, direction: ParameterDirection.Input);

            var query = @"UPDATE [Sets] SET             
                        id_team1 = @id_team1,
                        id_team2 = @id_team2,
                        pts_team1 = @pts_team1,
                        pts_team2 = @pts_team2,
                        id_replacement_team1 = @id_replacement_team1,
                        id_replacement_team2 = @id_replacement_team2,
                        start_time = @start_time,
                        end_time = @end_time,
                        id_game = @id_game       
                        WHERE id_set = @id_set";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;

        }
        #endregion
    }

}

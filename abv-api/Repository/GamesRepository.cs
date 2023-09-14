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

        #region GET POR ID
        public async Task<Games> GetGame(int id_game)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_game", id_game, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM Games WHERE id_game = @id_game";
            var response = await Instance.QueryFirstAsync<Games>(query, param);
            return response;
        }
        #endregion

        #region POST
        public async Task<bool> CreateGames(Games model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_team1", model.id_team1, direction: ParameterDirection.Input);
            param.Add("id_team2", model.id_team2, direction: ParameterDirection.Input);
            param.Add("game_date", model.game_date, direction: ParameterDirection.Input);
            param.Add("id_set1", model.id_set1, direction: ParameterDirection.Input);
            param.Add("id_set2", model.id_set2, direction: ParameterDirection.Input);
            param.Add("id_set3", model.id_set3, direction: ParameterDirection.Input);
            param.Add("start_time", model.start_time, direction: ParameterDirection.Input);
            param.Add("end_time", model.end_time, direction: ParameterDirection.Input);
            param.Add("total_game_time", model.total_game_time, direction: ParameterDirection.Input);
            var query = @"INSERT INTO Games (id_team1, id_team2, game_date, id_set1, id_set2, id_set3, start_time, end_time, total_game_time) 
                          VALUES (@id_team1, @id_team2, @game_date, @id_set1, @id_set2, @id_set3, @start_time, @end_time, @total_game_time)  ";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;   
    }
        #endregion
   
        #region PUT
        public async Task<bool> UpdateGame(Games model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); 
            var param = new DynamicParameters();
            param.Add("id_game", model.id_game, direction: ParameterDirection.Input);
            param.Add("id_team1", model.id_team1, direction: ParameterDirection.Input);
            param.Add("id_team2", model.id_team2, direction: ParameterDirection.Input);
            param.Add("game_date", model.game_date, direction: ParameterDirection.Input);
            param.Add("id_set1", model.id_set1, direction: ParameterDirection.Input);
            param.Add("id_set2", model.id_set2, direction: ParameterDirection.Input);
            param.Add("id_set3", model.id_set3, direction: ParameterDirection.Input);
            param.Add("start_time", model.start_time, direction: ParameterDirection.Input);
            param.Add("end_time", model.end_time, direction: ParameterDirection.Input);
            param.Add("total_game_time", model.total_game_time, direction: ParameterDirection.Input);
            var query = @"UPDATE Games SET
                         id_team1 = @id_team1,
                         id_team2 = @id_team2,
                         game_date = @game_date,
                         id_set1 = @id_set1,
                         id_set2 = @id_set2,
                         id_set3 = @id_set3,
                         start_time = @start_time,
                         end_time = @end_time,
                         total_game_time = @total_game_time
                         WHERE id_game = @id_game";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion
    }
}

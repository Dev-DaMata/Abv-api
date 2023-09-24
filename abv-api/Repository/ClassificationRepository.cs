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

        #region POST
        public async Task<bool> CreateClassification(Classification model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_game", model.id_game, direction: ParameterDirection.Input);
            param.Add("name", model.name, direction: ParameterDirection.Input);
            param.Add("classif", model.classif, direction: ParameterDirection.Input);
            param.Add("pts", model.pts, direction: ParameterDirection.Input);
            param.Add("win", model.win, direction: ParameterDirection.Input);
            param.Add("loss", model.loss, direction: ParameterDirection.Input);
            param.Add("sp", model.sp, direction: ParameterDirection.Input);
            param.Add("sc", model.sc, direction: ParameterDirection.Input);
            param.Add("ss", model.ss, direction: ParameterDirection.Input);
            param.Add("pp", model.pp, direction: ParameterDirection.Input);
            param.Add("pc", model.pc, direction: ParameterDirection.Input);
            param.Add("points_balance", model.points_balance, direction: ParameterDirection.Input);
            var query = @"INSERT INTO [Classification] (id_game, [name], classif,  pts, win, loss, sp, sc, ss, pp, pc, points_balance)
                        VALUES (@id_game, @name, @classif,  @pts, @win, @loss, @sp, @sc, @ss, @pp, @pc, @points_balance);";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion

        #region PUT
        public async Task<bool> UpdateClassification(Classification model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_classification", model.id_classification, direction: ParameterDirection.Input);
            param.Add("id_game", model.id_game, direction: ParameterDirection.Input);
            param.Add("name", model.name, direction: ParameterDirection.Input);
            param.Add("classif", model.classif, direction: ParameterDirection.Input);
            param.Add("pts", model.pts, direction: ParameterDirection.Input);
            param.Add("win", model.win, direction: ParameterDirection.Input);
            param.Add("loss", model.loss, direction: ParameterDirection.Input);
            param.Add("sp", model.sp, direction: ParameterDirection.Input);
            param.Add("sc", model.sc, direction: ParameterDirection.Input);
            param.Add("ss", model.ss, direction: ParameterDirection.Input);
            param.Add("pp", model.pp, direction: ParameterDirection.Input);
            param.Add("pc", model.pc, direction: ParameterDirection.Input);
            param.Add("points_balance", model.points_balance, direction: ParameterDirection.Input);
            var query = @"UPDATE [Classification] SET
                         id_game = @id_game,
                         [name] = @name,
                         classif = @classif,
                         pts = @pts,
                         win = @win,
                         loss = @loss,
                         sp = @sp,
                         sc = @sc,
                         ss = @ss,
                         pp = @pp,
                         pc = @pc,
                         points_balance = @points_balance
                         WHERE id_classification = @id_classification";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion
    }
}

﻿using Dapper;
using abv_api.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace abv_api.Repository
{
    public class UsersRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public UsersRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region GET 
        public async Task<List<Users>> GetUsers()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); //instanciando a conexão
            var query = "SELECT * FROM [User]"; //query
            var users =  Instance.Query<Users>(query).ToList(); //executando a query
            return users;
        }
        #endregion

        #region GET POR ID
        public async Task<Users> GetUser (int id_user)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_user", id_user, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM [User] WHERE id_user = @id_user";
            var response = await Instance.QueryFirstAsync<Users>(query, param);//variavel que esta executando a query
            return response;
        }
        #endregion

        #region POST
        public async Task<bool> CreateUser(Users model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_type_user", model.id_type_user, direction: ParameterDirection.Input);
            param.Add("name", model.name, direction: ParameterDirection.Input);
            param.Add("password", model.password, direction: ParameterDirection.Input);
            param.Add("email", model.email, direction: ParameterDirection.Input);
            param.Add("rg", model.rg, direction: ParameterDirection.Input);
            param.Add("date_of_birth", model.date_of_birth, direction: ParameterDirection.Input);
            var query = @"INSERT INTO [User] (id_type_user, name, password, email, rg, date_of_birth)
                            VALUES (@id_type_user, @name, @password, @email, @rg, @date_of_birth);";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion

        #region PUT
        public async Task<bool> UpdateUser(Users model)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_user", model.id_user, direction: ParameterDirection.Input);
            param.Add("id_type_user", model.id_type_user, direction: ParameterDirection.Input);
            param.Add("name", model.name, direction: ParameterDirection.Input);
            param.Add("password", model.password, direction: ParameterDirection.Input);
            param.Add("email", model.email, direction: ParameterDirection.Input);
            param.Add("rg", model.rg, direction: ParameterDirection.Input);
            param.Add("date_of_birth", model.date_of_birth, direction: ParameterDirection.Input);

            var query = @"UPDATE [User] SET             
                        id_type_user = @id_type_user,
                        name = @name,
                        password = @password,
                        email = @email,
                        rg = @rg,
                        date_of_birth = @date_of_birth
                        WHERE id_user = @id_user";

            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion

        #region DELETE  
        public async Task<bool> DeleteUser (int id_user)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_user", id_user, direction: ParameterDirection.Input);
            var query = @"DELETE FROM [User] WHERE id_user = @id_user";
            var response = await Instance.ExecuteAsync(query, param);
            return response > 0;
        }
        #endregion
    }
}

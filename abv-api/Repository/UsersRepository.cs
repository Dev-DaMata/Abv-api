﻿using Dapper;
using abv_api.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

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
            var Instance = new SqlConnection(connection);
            var query = "SELECT * FROM [User]";
            var users = Instance.Query<Users>(query).ToList();
            return users;
        }
        #endregion
    }
}

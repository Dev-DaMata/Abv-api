using Dapper;
using abv_api.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace abv_api.Repository
{
    public class TypeUsersRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public TypeUsersRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region GET
        public async Task<List<TypeUsers>> GetTypeUsers()
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection); //instanciando a conexão
            var query = "SELECT * FROM TypeUser"; //query
            var users = Instance.Query<TypeUsers>(query).ToList(); //executando a query
            return users;
        }
        #endregion
    }
}

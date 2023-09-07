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

        #region GET ID
        public async Task<TypeUsers> GetTypeUser(int id_type_user)
        {
            var connection = _config.GetConnectionString("DefaultConnection");
            var Instance = new SqlConnection(connection);
            var param = new DynamicParameters();
            param.Add("id_type_user", id_type_user, direction: ParameterDirection.Input);
            var query = @"SELECT * FROM TypeUser WHERE id_type_user = @id_type_user";
            var response = await Instance.QueryFirstAsync<TypeUsers>(query, param);//variavel que esta executando a query
            return response;

        }
        #endregion
    }
}

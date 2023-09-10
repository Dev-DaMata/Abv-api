using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;

namespace abv_api.Controllers
{
    [ApiController] //mapeando o swagger
    [Route("[controller]")]//mapeando o swagger

    public class UsersController : Controller
    {
        #region Injeção de Dependências 

        // Configuração da conexão do banco com o microsserviço
        private readonly IConfiguration _config;

        // Configuração e injeção dos Log de erros usando a biblioteca "Serilog"
        private readonly ILogger<UsersController> _logger;

        // Declarando Repository dos veiculos para retornar logs
        private readonly UsersRepository _usersRepository;

        // Declarando e armazenando as configurações de dependências
        public UsersController(IConfiguration config, ILogger<UsersController> logger, UsersRepository UsersRepository)
        {
            _config = config;
            _logger = logger;
            _usersRepository = UsersRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var data = await _usersRepository.GetUsers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetUsers: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }

        #endregion

        #region GET POR ID
        [HttpGet]
        [Route("GetUser/{id_user}")]
        public async Task<ActionResult<TypeUsers>> GetUser(int id_user)
        {
            try
            {
                var data = await _usersRepository.GetUser(id_user);
                return Ok(data);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "GetUser: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("createUsers")]
        public async Task<ActionResult<bool>> CreateUser (Users model)
        {
            try
            {
                var data = await _usersRepository.CreateUser(model);
                return Ok(data);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "CreateUser: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("updateUser")]
        public async Task<ActionResult<bool>> UpdateUser (Users model)
        {
            try
            {
                var data = await _usersRepository.UpdateUser(model);
                return Ok(data);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "UpdateUser: Erro na requisição");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("deleteUser")]
        public async Task<ActionResult<bool>> DeleteUser (int id_user)
        {
            try
            {
                var data = await _usersRepository.DeleteUser(id_user);
                return Ok(data);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "DeleteUser: Erro na requisição");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;

namespace abv_api.Controllers
{
    [ApiController] //mapeando o swagger
    [Route("[controller]")]//mapeando o swagger

    public class TypeUsersController : Controller
    {

        #region Injeção de Dependências 

        // Configuração da conexão do banco com o microsserviço
        private readonly IConfiguration _config;

        // Configuração e injeção dos Log de erros usando a biblioteca "Serilog"
        private readonly ILogger<TypeUsersController> _logger;

        // Declarando Repository dos veiculos para retornar logs
        private readonly TypeUsersRepository _typeusersRepository;

        // Declarando e armazenando as configurações de dependências
        public TypeUsersController(IConfiguration config, ILogger<TypeUsersController> logger, TypeUsersRepository TypeUsersRepository)
        {
            _config = config;
            _logger = logger;
            _typeusersRepository = TypeUsersRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetTypeUser")]
        public async Task<ActionResult> GetTypeUsers()
        {
            try
            {
                var data = await _typeusersRepository.GetTypeUsers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTypeUsers: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region GET POR ID
        [HttpGet]
        [Route("getTypeUser/{id_type_user}")]
        public async Task<ActionResult<TypeUsers>> GetTypeUser(int id_type_user)
        {
            try
            {
                var data = await _typeusersRepository.GetTypeUser(id_type_user);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTypeUser: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }
        #endregion

        #region POST
        [HttpPost]
        [Route("createTypeUsers")]
        public async Task<ActionResult<bool>> CreateTypeUser(string type_name, bool administrator)
        {
            try
            {
                var data = await _typeusersRepository.CreateTypeUser(type_name, administrator);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateTypeUser: Erro na requisição dos dados");
                return false;
            }

        }
        #endregion
    }

}

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
    }
}

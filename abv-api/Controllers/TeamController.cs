using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;

namespace abv_api.Controllers
{
    [ApiController] //mapeando o swagger
    [Route("[controller]")]//mapeando o swagger

    public class TeamController : Controller
    {
        #region Injeção de Dependências 

        // Configuração da conexão do banco com o microsserviço
        private readonly IConfiguration _config;

        // Configuração e injeção dos Log de erros usando a biblioteca "Serilog"
        private readonly ILogger<TeamController> _logger;

        // Declarando Repository dos veiculos para retornar logs
        private readonly TeamRepository _teamRepository;

        // Declarando e armazenando as configurações de dependências
        public TeamController(IConfiguration config, ILogger<TeamController> logger, TeamRepository TeamRepository)
        {
            _config = config;
            _logger = logger;
            _teamRepository = TeamRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetTeams")]
        public async Task<ActionResult> GetTeams()
        {
            try
            {
                var data = await _teamRepository.GetTeams();
                return Ok(data);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "GetUsers: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region GET POR ID  
        [HttpGet]
        [Route("GetTeam/{id_team}")]
        public async Task<ActionResult> GetTeam(int id_team)
        {
            try
            {
                var data = await _teamRepository.GetTeam(id_team);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetUsers: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("CreateTeam")]
        public async Task<ActionResult<bool>> CreateTeam(Team model)
        {
            try
            {
                var data = await _teamRepository.CreateTeam(model);
                return Ok(data);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "CreatePost: Erro na requisição de dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("updateTeam")]
        public async Task<ActionResult<bool>> UpdateTeam(Team model)
        {
            try
            {
                var data = await _teamRepository.UpdateTeam(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateUser: Erro na requisição");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

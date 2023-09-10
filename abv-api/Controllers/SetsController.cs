using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;

namespace abv_api.Controllers
{
    public class SetsController : Controller
    {
        #region Injeção de Dependências 

        // Configuração da conexão do banco com o microsserviço
        private readonly IConfiguration _config;

        // Configuração e injeção dos Log de erros usando a biblioteca "Serilog"
        private readonly ILogger<SetsController> _logger;

        // Declarando Repository dos veiculos para retornar logs
        private readonly SetsRepository _setsRepository;

        // Declarando e armazenando as configurações de dependências
        public SetsController(IConfiguration config, ILogger<SetsController> logger, SetsRepository SetsRepository)
        {
            _config = config;
            _logger = logger;
            _setsRepository = SetsRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetSets")]
        public async Task<ActionResult> GetSets()
        {
            try
            {
                var data = await _setsRepository.GetSets();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetSets: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region GET POR ID  
        [HttpGet]
        [Route("GetReplacement/{id_set}")]
        public async Task<ActionResult> GetSet(int id_set)
        {
            try
            {
                var data = await _setsRepository.GetSet(id_set);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetReplacement: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("CreateSets")]
        public async Task<ActionResult<bool>> CreateSets(Sets model)
        {
            try
            {
                var data = await _setsRepository.CreateSets(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateSets: Erro na requisição de dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

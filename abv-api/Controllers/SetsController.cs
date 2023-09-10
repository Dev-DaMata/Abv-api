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
    }
}

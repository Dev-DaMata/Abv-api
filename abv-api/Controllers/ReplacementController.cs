﻿using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;
namespace abv_api.Controllers
{
    [ApiController] //mapeando o swagger
    [Route("[controller]")]//mapeando o swagger
    public class ReplacementController : Controller
    {
        #region Injeção de Dependências 

        // Configuração da conexão do banco com o microsserviço
        private readonly IConfiguration _config;

        // Configuração e injeção dos Log de erros usando a biblioteca "Serilog"
        private readonly ILogger<ReplacementController> _logger;

        // Declarando Repository dos veiculos para retornar logs
        private readonly ReplacementRepository _replacementRepository;

        // Declarando e armazenando as configurações de dependências
        public ReplacementController(IConfiguration config, ILogger<ReplacementController> logger, ReplacementRepository ReplacementRepository)
        {
            _config = config;
            _logger = logger;
            _replacementRepository = ReplacementRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetReplacement")]
        public async Task<ActionResult> GetReplacements()
        {
            try
            {
                var data = await _replacementRepository.GetReplacements();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetReplacements: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

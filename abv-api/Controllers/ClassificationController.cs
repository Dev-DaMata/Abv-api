using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace abv_api.Controllers
{
    public class ClassificationController : Controller
    {
        #region Injeção de dependências
        private readonly IConfiguration _config;

        private readonly ILogger<ClassificationController> _logger;

        private readonly ClassificationRepository _classificationRepository;

        public ClassificationController(IConfiguration config, ILogger<ClassificationController> logger, ClassificationRepository classificationRepository)
        {
            _config = config;
            _logger = logger;
            _classificationRepository = classificationRepository;
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("GetClassification")]
        public async Task<ActionResult> GetClassifications()
        {
            try
            {
                var data = await _classificationRepository.GetClassifications();
                return Ok(data); 
            } catch (Exception ex)
            {
                _logger.LogError(ex, "GetClassifications: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region GET POR ID
        [HttpGet]
        [Route("GetClassification/{id_classification}")]
        public async Task<ActionResult> GetClassification(int id_classification)
        {
            try
            {
                var data = await _classificationRepository.GetClassification(id_classification);
                return Ok(data);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "GetClassification: Erro na requisição de dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

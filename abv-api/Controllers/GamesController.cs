using Microsoft.AspNetCore.Mvc;
using abv_api.Model;
using abv_api.Repository;
using System.Reflection;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace abv_api.Controllers
{
    public class GamesController : Controller
    {
        #region Injeção de Dependências
        private readonly IConfiguration _config;

        private readonly ILogger<GamesController> _logger;

        private readonly GamesRepository _gamesRepository;

        public GamesController(IConfiguration config, ILogger<GamesController> logger, GamesRepository gamesRepository)
        {
            _config = config;
            _logger = logger;
            _gamesRepository = gamesRepository;
        }

        #endregion

        #region GET
        [HttpGet]
        [Route("GetGames")]
        public async Task<ActionResult> GetGames()
        {
            try
            {
                var data = await _gamesRepository.GetGames();
                return Ok(data);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "GetGames: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region GET POR ID
        [HttpGet]
        [Route("GetGame/{id_game}")]
        public async Task<ActionResult> GetGame(int id_game)
        {
            try
            {
                var data = await _gamesRepository.GetGame(id_game);
                return Ok(data);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "GetGame: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

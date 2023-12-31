﻿using Microsoft.AspNetCore.Mvc;
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

        #region POST
        [HttpPost]
        [Route("CreateGame")]
        public async Task<ActionResult<bool>> CreateGames(Games model)
        {
            try
            {
                var data = await _gamesRepository.CreateGames(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateGames: Erro na reuisição dos dados");
               return new StatusCodeResult(500);
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("UpdateGame")]
        public async Task<ActionResult<bool>> UpdateGame(Games model)
        {
            try
            {
                var data = await _gamesRepository.UpdateGame(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateGame: erro na requisição");
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("DeleteGame")]
        public async Task<ActionResult<bool>> DeleteGame(int id_game)
        {
            try
            {
                var data = await _gamesRepository.DeleteGame(id_game);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteGame: Erro na requisição");
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}

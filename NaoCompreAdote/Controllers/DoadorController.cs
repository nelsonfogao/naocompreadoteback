using Application.Dto;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [ApiController]
    [Route("api/doadores")]
    public class DoadorController : ControllerBase
    {
        private readonly IDoadorService _doadorService;
        public DoadorController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }

        /// <summary>
        /// Consulta doadores
        /// </summary>
        /// <param name="id">Identificação do doador</param>
        /// <returns code="200">doador</returns>
        /// <response code="404">Nenhuma conta encontrada</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoadorDto), 200)]
        public async Task<IActionResult> GetDoadorByIdAsync(Guid id)
        {
            return Ok(await _doadorService.GetDoadorByIdAsync(id));
        }


        /// <summary>
        /// Login doadores
        /// </summary>
        /// <returns code="200">doador</returns>
        /// <returns code="204">login invalido</returns>
        [HttpGet("login")]
        [ProducesResponseType(typeof(DoadorDto), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> LoginDoadorAsync(string email, string senha)
        {
            return Ok(await _doadorService.LoginDoadorAsync(email, senha));
        }


        /// <summary>
        /// Consulta todas as contas
        /// </summary>
        /// <returns code="200">Todas as contas encontradas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<DoadorDto>), 200)]
        public async Task<IActionResult> GetDoadoresAsync()
        {
            return Ok(await _doadorService.GetDoadoresAsync());
        }
        /// <summary>
        /// Cadastro de um novo doador
        /// </summary>
        /// <param name="doador">Dados do consumidor a serem cadastrados</param>
        /// <response code="201">Cadastrado com sucesso</response>  
        [ProducesResponseType(201)]
        [HttpPost()]
        public async Task<IActionResult> PostDoadorAsync([FromBody] CreateDoadorDto doador)
        {
            var result = await _doadorService.CreateDoadorAsync(doador);

            return Created("", result);
        }

    }
}

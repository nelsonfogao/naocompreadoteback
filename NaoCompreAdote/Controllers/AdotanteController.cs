using Application.Dto;
using Application.Interfaces.Services;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [ApiController]
    [Route("api/adotantes")]
    public class AdotanteController : ControllerBase
    {
        private readonly IAdotanteService _adotanteService;
        public AdotanteController(IAdotanteService adotanteService)
        {
            _adotanteService = adotanteService;
        }

        /// <summary>
        /// Consulta adotantes
        /// </summary>
        /// <param name="id">Identificação do adotante</param>
        /// <returns code="200">adotante</returns>
        /// <response code="404">Nenhuma conta encontrada</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdotanteDto), 200)]
        public async Task<IActionResult> GetAdotanteByIdAsync(Guid id)
        {
            return Ok(await _adotanteService.GetAdotanteByIdAsync(id));
        }


        /// <summary>
        /// Consulta todas as contas
        /// </summary>
        /// <returns code="200">Todas as contas encontradas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<AdotanteDto>), 200)]
        public async Task<IActionResult> GetAdotantesAsync()
        {
            return Ok(await _adotanteService.GetAdotantesAsync());
        }
        /// <summary>
        /// Cadastro de um novo adotante
        /// </summary>
        /// <param name="adotante">Dados do consumidor a serem cadastrados</param>
        /// <response code="201">Cadastrado com sucesso</response>  
        [ProducesResponseType(201)]
        [HttpPost()]
        public async Task<IActionResult> PostAdotanteAsync([FromBody] CreateAdotanteDto adotante)
        {
            var result = await _adotanteService.CreateAdotanteAsync(adotante);

            return Created("", result);
        }
        /// <summary>
        /// Cadastro de uma nova adocao
        /// </summary>
        /// <param name="adocao">dados para vincular</param>
        /// <response code="201">Cadastrado com sucesso</response>  
        [ProducesResponseType(201)]
        [HttpPost("adocao")]
        public async Task<IActionResult> PostAdotanteAsync([FromBody] CreateAdocaoDto adocao)
        {
            var result = await _adotanteService.CreateAdocoesAsync(adocao);

            return Created("",result);
        }
        /// <summary>
        /// Login adotantes
        /// </summary>
        /// <returns code="200">adotante</returns>
        /// <returns code="204">login invalido</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AdotanteDto), 200)]

        [ProducesResponseType(204)]
        public async Task<IActionResult> LoginAdotanteAsync([FromBody] LoginDto login)
        {
            return Ok(await _adotanteService.LoginAdotanteAsync(login.Email, login.Senha));
        }
        /// <summary>
        /// get adotantes por pet id
        /// </summary>
        /// <param name="id">Identificação do pet</param>
        /// <returns code="200">adotante</returns>
        /// <returns code="204">login invalido</returns>
        [HttpGet("adotantespet/{id}")]
        [ProducesResponseType(typeof(List<AdotanteDto>), 200)]
        public async Task<IActionResult> GetAdotantesByPetIdAsync([FromRoute]Guid id)
        {
            return Ok(await _adotanteService.GetAdotantesByPetIdAsync(id));
        }

    }
}

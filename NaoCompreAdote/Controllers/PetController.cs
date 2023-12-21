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
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        /// <summary>
        /// Consulta pets
        /// </summary>
        /// <param name="id">Identificação do pet</param>
        /// <returns code="200">pet</returns>
        /// <response code="404">Nenhuma conta encontrada</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PetDto), 200)]
        public async Task<IActionResult> GetPetByIdAsync(Guid id)
        {
            return Ok(await _petService.GetPetByIdAsync(id));
        }


        /// <summary>
        /// Consulta todas os pets
        /// </summary>
        /// <returns code="200">Todas os pets encontrados</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PetDto>), 200)]
        public async Task<IActionResult> GetPetsAsync()
        {
            return Ok(await _petService.GetPetsAsync());
        }
        /// <summary>
        /// Cadastro de um novo pet
        /// </summary>
        /// <param name="id">Identificação do doador</param>
        /// <param name="pet">Dados do pet cadastrados</param>
        /// <response code="201">Cadastrado com sucesso</response>  
        [ProducesResponseType(201)]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostPetAsync([FromBody] CreatePetDto pet, Guid id)
        {
            var result = await _petService.CreatePetAsync(pet, id);

            return Created("", result);
        }
        /// <summary>
        /// get pets por nao ter sido favoritado pelo doador id
        /// </summary>
        /// <param name="id">Identificação do doador</param>
        /// <returns code="200">achou</returns>
        /// <returns code="204">invalido</returns>
        [HttpGet("adotantesPet/{id}")]
        [ProducesResponseType(typeof(PetDto), 200)]
        public async Task<IActionResult> GetPetsByNonFavoriteAsync([FromRoute] Guid id)
        {
            return Ok(await _petService.GetPetsByNonFavoriteAsync(id));
        }

    }
}

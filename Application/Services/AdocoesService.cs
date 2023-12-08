using Application.Dto;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.WebRequestMethods;

namespace Application.Services
{
    public class AdocoesService : IAdocoesService
    {
        private readonly IAdocoesRepository _adocoesRepository;
        public AdocoesService(IAdocoesRepository adocoesRepository)
        {
            _adocoesRepository = adocoesRepository;
        }

        public async Task<IEnumerable<AdocoesDto>> GetAdocoesAsync()
        {
            var adocoes = await _adocoesRepository.GetAdocoesAsync();
            var adocoesDto = adocoes.Select(x => new AdocoesDto()
            {
                AdotanteId = x.AdotanteId,
                PetId = x.PetId

            }).ToList();
            return adocoesDto;
      
        }

        public async Task CreateAdocaoAsync(CreateAdocaoDto adocao)
        {
            await _adocoesRepository.CreateAdocaoAsync(new Adocoes()
            {
                AdotanteId = adocao.AdotanteId,
                PetId = adocao.PetId
            });

        }
    }
}

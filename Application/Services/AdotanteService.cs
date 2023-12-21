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
    public class AdotanteService : IAdotanteService
    {
        private readonly IAdotanteRepository _adotanteRepository;
        private readonly IAdocoesService _adocoesService;
        public AdotanteService(IAdotanteRepository adotanteRepository, IAdocoesService adocoesService)
        {
            _adotanteRepository = adotanteRepository;
            _adocoesService = adocoesService;
        }

        public async Task<IEnumerable<AdotanteDto>> GetAdotantesAsync()
        {
            var adotantes = await _adotanteRepository.GetAdotantesAsync();
            var adocoes = await _adocoesService.GetAdocoesAsync();


            var adotantesDto = adotantes.Select(x => new AdotanteDto()
            {
                AdotanteId = x.AdotanteId,
                Nome = x.Nome,
                Email = x.Email,
                Senha = x.Senha,
                Telefone = x.Telefone,
                Endereco = x.Endereco,
                CPF = x.CPF,
                FotoUrl = x.FotoUrl,
                Adocoes = x.Adocoes != null ? adocoes.Where(x=> x.AdotanteId == x.AdotanteId).ToList(): new List<AdocoesDto>(),
            }).ToList();
            return adotantesDto;
        }
        public async Task<AdotanteDto> GetAdotanteByIdAsync(Guid id)
        {
            var adotante = await _adotanteRepository.GetAdotanteByIdAsync(id);
            var adocoes = await _adocoesService.GetAdocoesAsync();
            return new AdotanteDto()
            {
                AdotanteId = adotante.AdotanteId,
                Nome = adotante.Nome,
                Email = adotante.Email,
                Senha = adotante.Senha,
                Telefone = adotante.Telefone,
                Endereco = adotante.Endereco,
                CPF = adotante.CPF,
                FotoUrl = adotante.FotoUrl, 
                Adocoes = adotante.Adocoes != null ? adocoes.Where(x => x.AdotanteId == x.AdotanteId).ToList() : new List<AdocoesDto>(),

            };
        }

        public async Task<AdotanteDto> CreateAdotanteAsync(CreateAdotanteDto adotante)
        {
            var newAdotante = await _adotanteRepository.CreateAdotanteAsync(new Adotante()
            {
                AdotanteId = Guid.NewGuid(),
                Nome = adotante.Nome,
                Email = adotante.Email,
                Senha = adotante.Senha,
                Telefone = adotante.Telefone,
                Endereco = adotante.Endereco,
                CPF = adotante.CPF,
            });
            return new AdotanteDto()
            {
                AdotanteId = newAdotante.AdotanteId,
                Nome = adotante.Nome,
                Email = adotante.Email,
                Endereco = adotante.Endereco,
                CPF = adotante.CPF,
            };
        }
        public async Task<AdocoesDto> CreateAdocoesAsync(CreateAdocaoDto adocao)
        {
             return await _adocoesService.CreateAdocaoAsync(adocao);
        }

        public async Task<AdotanteDto> LoginAdotanteAsync(string email, string senha)
        {
            var login = await _adotanteRepository.GetAdotanteByEmailAsync(email);
            if (login == null)
                return null;
            if (login.Senha != senha)
                return null;
            var adocoes = await _adocoesService.GetAdocoesAsync();
            return new AdotanteDto()
            {
                AdotanteId = login.AdotanteId,
                Nome = login.Nome,
                Email = login.Email,
                Senha = login.Senha,
                Telefone = login.Telefone,
                Endereco = login.Endereco,
                CPF = login.CPF,
                FotoUrl=login.FotoUrl,
                Adocoes = login.Adocoes != null ? adocoes.Where(x => x.AdotanteId == x.AdotanteId).ToList() : new List<AdocoesDto>(),
            };
        }
        public async Task<IEnumerable<AdotanteDto>> GetAdotantesByPetIdAsync(Guid petId)
        {
            var adocoes = await _adocoesService.GetAdocoesAsync();
            var adocoesPet = adocoes.Where(x => x.PetId == petId);
            if (!adocoesPet.Any())
                return null;
            var adotantes =  new List<AdotanteDto>();
            foreach (var i in adocoesPet)
            {
                adotantes.Add( await GetAdotanteByIdAsync(i.AdotanteId));
            }
            return adotantes;
        }
    }
}

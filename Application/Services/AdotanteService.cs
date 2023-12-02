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
        public AdotanteService(IAdotanteRepository adotanteRepository)
        {
            _adotanteRepository = adotanteRepository;
        }

        public async Task<IEnumerable<AdotanteDto>> GetAdotantesAsync()
        {
            var adotantes = await _adotanteRepository.GetAdotantesAsync();
            var adotantesDto = adotantes.Select(x => new AdotanteDto()
            {
                AdotanteId = x.AdotanteId,
                Nome = x.Nome,
                Email = x.Email,
                Endereco = x.Endereco,
                CPF = x.CPF,
                FotosAdotantes = x.FotosAdotantes != null ?
                x.FotosAdotantes.Select(y=> new FotosAdotantesDto()
                {
                    IdFoto = y.IdFoto,
                    AdotanteId=y.AdotanteId,
                    Link = y.Link,
                }).ToList(): new List<FotosAdotantesDto>(),
            }).ToList();
            return adotantesDto;
        }
        public async Task<AdotanteDto> GetAdotanteByIdAsync(Guid id)
        {
            var adotante = await _adotanteRepository.GetAdotanteByIdAsync(id);

            return new AdotanteDto()
            {
                AdotanteId = adotante.AdotanteId,
                Nome = adotante.Nome,
                Email = adotante.Email,
                Endereco = adotante.Endereco,
                CPF = adotante.CPF,
                FotosAdotantes = adotante.FotosAdotantes != null ?
                adotante.FotosAdotantes.Select(y => new FotosAdotantesDto()
                {
                    IdFoto = y.IdFoto,
                    AdotanteId = y.AdotanteId,
                    Link = y.Link,
                }).ToList() : new List<FotosAdotantesDto>(),

            };
        }

        public async Task<AdotanteDto> CreateAdotanteAsync(CreateAdotanteDto adotante)
        {
            var newAdotante = await _adotanteRepository.CreateAdotanteAsync(new Adotante()
            {
                AdotanteId = Guid.NewGuid(),
                Nome = adotante.Nome,
                Email = adotante.Email,
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
    }
}

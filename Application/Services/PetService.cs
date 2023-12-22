using Application.Dto;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.WebRequestMethods;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IAdocoesService _adocoesService;
        public PetService(IPetRepository petRepository, IAdocoesService adocoesService)
        {
            _petRepository = petRepository;
            _adocoesService = adocoesService;
        }

        public async Task<IEnumerable<PetDto>> GetPetsAsync()
        {
            var pets = await _petRepository.GetPetsAsync();

            var adocoes = await _adocoesService.GetAdocoesAsync();
            var petsDto = pets.Select(x => new PetDto()
            {
                    PetId = x.PetId,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    EhDog = x.EhDog,
                    DoadorId = x.DoadorId,
                    Disponivel = x.Disponivel,
                    FotoUrl = x.FotoUrl,
                    
                Adocoes = x.Adocoes != null ? adocoes.Where(x => x.PetId == x.PetId).ToList() : new List<AdocoesDto>()
            }).ToList();
            return petsDto;
        }
        public async Task<PetDto> GetPetByIdAsync(Guid id)
        {
            var pet = await _petRepository.GetPetByIdAsync(id);

            var adocoes = await _adocoesService.GetAdocoesAsync();

            return new PetDto()
            {
                    PetId = pet.PetId,
                    Nome = pet.Nome,
                    DataNascimento = pet.DataNascimento,
                    EhDog = pet.EhDog,
                    DoadorId = pet.DoadorId,
                    Disponivel = pet.Disponivel,
                    FotoUrl = pet.FotoUrl,
                    Adocoes = pet.Adocoes != null ? adocoes.Where(x => x.PetId == x.PetId).ToList() : new List<AdocoesDto>()
            };
        }

        public async Task<PetDto> CreatePetAsync(CreatePetDto createPet, Guid doadorId)
        {
            var pet = new Pet()
            {
                PetId = Guid.NewGuid(),
                Nome = createPet.Nome,
                DataNascimento = createPet.DataNascimento,
                EhDog = createPet.EhDog,
                DoadorId = doadorId,
                Disponivel = true,
                FotoUrl= createPet.FotoUrl,
            };
            var petNovo = _petRepository.CreatePetAsync(pet);
            var petDto = new PetDto()
            {
                PetId = pet.PetId,
                Nome = pet.Nome,
                DataNascimento = pet.DataNascimento,
                EhDog = pet.EhDog,
                DoadorId = doadorId,
                Disponivel = pet.Disponivel,
                FotoUrl = pet.FotoUrl,

            };
            return petDto;
        }
        public async Task<PetDto> GetPetsByNonFavoriteAsync(Guid adotanteId)
        {
            var random = new Random();
            var adocoes = await _adocoesService.GetAdocoesAsync();
            var adocoesPet = adocoes.Where(x => x.AdotanteId == adotanteId);
            var todosPets = GetPetsAsync().Result.ToList();
            var pets = new List<PetDto>();
            if (!adocoesPet.Any())
                return todosPets.ElementAtOrDefault(random.Next(0, todosPets.Count));
            foreach (var item in adocoesPet)
            {
                pets = todosPets.Where(x => x.PetId != item.PetId).ToList();
            }

            return pets.ElementAtOrDefault(random.Next(0, pets.Count));
        }
    }
}

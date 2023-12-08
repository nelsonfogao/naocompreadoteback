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
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<IEnumerable<PetDto>> GetPetsAsync()
        {
            var pets = await _petRepository.GetPetsAsync();
            var petsDto = pets.Select(x => new PetDto()
            {
                    PetId = x.PetId,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    EhDog = x.EhDog,
                    DoadorId = x.DoadorId,
                    Disponivel = x.Disponivel,
                    Caracteristicas = x.Caracteristicas != null ? x.Caracteristicas.Select(y => new CaracteristicasDto()
                    {
                        IdCaracteristica = y.IdCaracteristica,
                        Nome = y.Nome
                    }).ToList(): new List<CaracteristicasDto> (),
                    FotosPet = x.FotosPet != null ? x.FotosPet.Select(y => new FotosPetsDto()
                {
                    IdFoto = y.IdFoto,
                    PetId = y.PetId,
                    Link = y.Link,
                }).ToList() : new List<FotosPetsDto>(),
            }).ToList();
            return petsDto;
        }
        public async Task<PetDto> GetPetByIdAsync(Guid id)
        {
            var pet = await _petRepository.GetPetByIdAsync(id);

            return new PetDto()
            {
                    PetId = pet.PetId,
                    Nome = pet.Nome,
                    DataNascimento = pet.DataNascimento,
                    EhDog = pet.EhDog,
                    DoadorId = pet.DoadorId,
                    Disponivel = pet.Disponivel,
                    Caracteristicas = pet.Caracteristicas != null ? pet.Caracteristicas.Select(y => new CaracteristicasDto()
                    {
                        IdCaracteristica = y.IdCaracteristica,
                        Nome = y.Nome
                    }).ToList() : new List<CaracteristicasDto>(),
                    FotosPet = pet.FotosPet != null ? pet.FotosPet.Select(y => new FotosPetsDto()
                    {
                        IdFoto = y.IdFoto,
                        PetId = y.PetId,
                        Link = y.Link,
                    }).ToList(): new List<FotosPetsDto>(),
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
                Caracteristicas = createPet.Caracteristicas != null ? createPet.Caracteristicas.Select(y => new Caracteristicas()
                {
                    IdCaracteristica = y.IdCaracteristica,
                    Nome = y.Nome
                }).ToList() : new List<Caracteristicas>(),
                FotosPet = createPet.FotosPet != null ? createPet.FotosPet.Select(y => new FotosPets()
                {
                    IdFoto = y.IdFoto,
                    PetId = y.PetId,
                    Link = y.Link,
                }).ToList() : new List<FotosPets> ()
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
                Caracteristicas =  pet.Caracteristicas != null ? pet.Caracteristicas.Select(y => new CaracteristicasDto()
                {
                    IdCaracteristica = y.IdCaracteristica,
                    Nome = y.Nome
                }).ToList() : new List<CaracteristicasDto>(),
                FotosPet = createPet!= null ?createPet.FotosPet.Select(y => new FotosPetsDto()
                {
                    IdFoto = y.IdFoto,
                    PetId = y.PetId,
                    Link = y.Link,
                }).ToList() : new List<FotosPetsDto> ()
            };
            return petDto;
        }
    }
}

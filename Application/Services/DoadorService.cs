using Application.Dto;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly IDoadorRepository _doadorRepository;
        private readonly IPetService _petService;
        public DoadorService(IDoadorRepository doadorRepository, IPetService petService)
        {
            _doadorRepository = doadorRepository;
            _petService = petService;
        }

        public async Task<IEnumerable<DoadorDto>> GetDoadoresAsync()
        {
            var doadores = await _doadorRepository.GetDoadoresAsync();
            var pets = _petService.GetPetsAsync().Result;
            var doadoresDto = doadores.Select(x => new DoadorDto()
            {
                DoadorId = x.DoadorId,
                Nome = x.Nome,
                Email = x.Email,
                Endereco = x.Endereco,
                Pets = x.Pets != null ?
                x.Pets.Select(y => new PetDto()
                {
                    PetId = y.PetId,
                    Nome = y.Nome,
                    DataNascimento = y.DataNascimento,
                    EhDog = y.EhDog,
                    DoadorId = y.DoadorId,
                    Disponivel = y.Disponivel,
                    FotosPet = y.FotosPet!= null ? y.FotosPet.Select(y => new FotosPetsDto()
                    {
                        IdFoto = y.IdFoto,
                        PetId = y.PetId,
                        Link = y.Link,
                    }).ToList(): new List<FotosPetsDto>(),
                    Caracteristicas = y.Caracteristicas != null? y.Caracteristicas.Select(y => new CaracteristicasDto()
                    {
                        IdCaracteristica = y.IdCaracteristica,
                        Nome = y.Nome
                    }).ToList() : new List<CaracteristicasDto>(),
                }).ToList() : new List<PetDto>()
            }).ToList();
            return doadoresDto;
        }
        public async Task<DoadorDto> GetDoadorByIdAsync(Guid id)
        {
            var doador = await _doadorRepository.GetDoadorByIdAsync(id);

            var pets = _petService.GetPetsAsync().Result;

            return new DoadorDto()
            {
                DoadorId = doador.DoadorId,
                Nome = doador.Nome,
                Email = doador.Email,
                Endereco = doador.Endereco,
                Pets = pets.Where(z => z.DoadorId == doador.DoadorId) != null ?
                doador.Pets.Select(y => new PetDto()
                {
                    PetId = y.PetId,
                    Nome = y.Nome,
                    DataNascimento = y.DataNascimento,
                    EhDog = y.EhDog,
                    DoadorId = y.DoadorId,
                    Disponivel = y.Disponivel,
                    Caracteristicas = y.Caracteristicas != null ? y.Caracteristicas.Select(y => new CaracteristicasDto()
                    {
                        IdCaracteristica = y.IdCaracteristica,
                        Nome = y.Nome
                    }).ToList() : new List<CaracteristicasDto>(),
                    FotosPet = y.FotosPet != null ? y.FotosPet.Select(y => new FotosPetsDto()
                    {
                        IdFoto = y.IdFoto,
                        PetId = y.PetId,
                        Link = y.Link,
                    }).ToList(): new List<FotosPetsDto>(),
                }).ToList(): new List<PetDto>()
            };
        }

        public async Task<DoadorDto> CreateDoadorAsync(CreateDoadorDto doador)
        {
            var newDoador = await _doadorRepository.CreateDoadorAsync(new Doador()
            {
                DoadorId = Guid.NewGuid(),
                Nome = doador.Nome,
                Email = doador.Email,
                Endereco = doador.Endereco,
                Pets = new List<Pet>()
            });
            return new DoadorDto()
            {
                DoadorId = newDoador.DoadorId,
                Nome = doador.Nome,
                Email = doador.Email,
                Endereco = doador.Endereco
            };
        }
        
    }
}

using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetPetsAsync();
        Task<PetDto> GetPetByIdAsync(Guid id);
        Task<PetDto> CreatePetAsync(CreatePetDto pet, Guid doadorId);
    }
}

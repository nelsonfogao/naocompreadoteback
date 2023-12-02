using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<Pet> GetPetByIdAsync(Guid id);
        Task<Pet> CreatePetAsync(Pet pet);
    }
}

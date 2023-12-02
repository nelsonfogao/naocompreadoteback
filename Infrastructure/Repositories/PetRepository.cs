using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private WebApiContext _context { get; set; }

        public PetRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {
            var result = await _context.Pets.ToListAsync();
            return result;
        }
        public async Task<Pet> GetPetByIdAsync(Guid id)
        {
            var result = await _context.Pets.FirstOrDefaultAsync(x => x.PetId == id);
            return result;
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            _context.SaveChanges();
            var result = await GetPetByIdAsync(pet.PetId);
            return result;
        }

    }
}

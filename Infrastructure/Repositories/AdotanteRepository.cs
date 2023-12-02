using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AdotanteRepository : IAdotanteRepository
    {
        private WebApiContext _context { get; set; }

        public AdotanteRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Adotante>> GetAdotantesAsync()
        {
            var result = await _context.Adotantes.ToListAsync();
            return result;
        }
        public async Task<Adotante> GetAdotanteByIdAsync(Guid id)
        {
            var result = await _context.Adotantes.FirstOrDefaultAsync(x => x.AdotanteId == id);
            return result;
        }

        public async Task<Adotante> CreateAdotanteAsync(Adotante adotante)
        {
            await _context.Adotantes.AddAsync(adotante);
            _context.SaveChanges();
            var result = await GetAdotanteByIdAsync(adotante.AdotanteId);
            return result;
        }

    }
}
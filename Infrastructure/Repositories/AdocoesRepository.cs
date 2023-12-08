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
    public class AdocoesRepository : IAdocoesRepository
    {
        private WebApiContext _context { get; set; }

        public AdocoesRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Adocoes>> GetAdocoesAsync()
        {
            var result = await _context.Adocoes.ToListAsync();
            return result;
        }

        public async Task CreateAdocaoAsync(Adocoes adocoes)
        {
            await _context.Adocoes.AddAsync(adocoes);
            _context.SaveChanges();
        }

    }
}
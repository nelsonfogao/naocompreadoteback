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
    public class DoadorRepository : IDoadorRepository
    {
        private WebApiContext _context { get; set; }

        public DoadorRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doador>> GetDoadoresAsync()
        {
            var result = await _context.Doadores.ToListAsync();
            return result;
        }
        public async Task<Doador> GetDoadorByIdAsync(Guid id)
        {
            var result = await _context.Doadores.FirstOrDefaultAsync(x => x.DoadorId == id);
            return result;
        }

        public async Task<Doador> CreateDoadorAsync(Doador doador)
        {
            await _context.Doadores.AddAsync(doador);
            _context.SaveChanges();
            var result = await GetDoadorByIdAsync(doador.DoadorId);
            return result;
        }

    }
}
using Application.Dto;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IDoadorRepository
    {
        Task<IEnumerable<Doador>> GetDoadoresAsync();
        Task<Doador> GetDoadorByIdAsync(Guid id);
        Task<Doador> CreateDoadorAsync(Doador doador);
    }
}
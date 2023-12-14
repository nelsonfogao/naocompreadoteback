using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IAdotanteRepository
    {
        Task<IEnumerable<Adotante>> GetAdotantesAsync();
        Task<Adotante> GetAdotanteByIdAsync(Guid id);
        Task<Adotante> CreateAdotanteAsync(Adotante adotante);
        Task<Adotante> GetAdotanteByEmailAsync(string email);
    }
}

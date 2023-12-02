using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAdotanteService
    {
        Task<IEnumerable<AdotanteDto>> GetAdotantesAsync();
        Task<AdotanteDto> GetAdotanteByIdAsync(Guid id);
        Task<AdotanteDto> CreateAdotanteAsync(CreateAdotanteDto adotante);
    }
}

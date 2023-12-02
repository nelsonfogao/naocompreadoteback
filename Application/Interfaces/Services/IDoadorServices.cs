using Application.Dto;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDoadorService
    {
        Task<IEnumerable<DoadorDto>> GetDoadoresAsync();
        Task<DoadorDto> GetDoadorByIdAsync(Guid id);
        Task<DoadorDto> CreateDoadorAsync(CreateDoadorDto doador);

    }
}

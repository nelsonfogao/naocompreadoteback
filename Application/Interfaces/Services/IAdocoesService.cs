using Application.Dto;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAdocoesService
    {
        Task CreateAdocaoAsync(CreateAdocaoDto adocao);
        Task<IEnumerable<AdocoesDto>> GetAdocoesAsync();
    }
}

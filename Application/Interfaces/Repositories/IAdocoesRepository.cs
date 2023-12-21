using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IAdocoesRepository
    {
        Task<IEnumerable<Adocoes>> GetAdocoesAsync();
        Task<Adocoes> CreateAdocaoAsync(Adocoes adocoes);
    }
}

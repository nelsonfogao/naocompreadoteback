using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AdotanteDto
    {
        public Guid AdotanteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string FotoUrl { get; set; }
        public IList<AdocoesDto> Adocoes { get; set; }


    }
}

using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PetDto
    {
        public Guid PetId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool EhDog { get; set; }
        public Guid DoadorId { get; set; }
        public bool Disponivel { get; set; }
        public List<FotosPetsDto> FotosPet { get; set; }
        public List<CaracteristicasDto> Caracteristicas { get; set; }


    }
}

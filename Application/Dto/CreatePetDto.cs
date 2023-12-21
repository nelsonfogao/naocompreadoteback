using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreatePetDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool EhDog { get; set; }
        public string FotoUrl { get; set; }
        public List<CaracteristicasDto> Caracteristicas { get; set; }

    }
}

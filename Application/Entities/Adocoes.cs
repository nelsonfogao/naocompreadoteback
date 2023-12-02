using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Adocoes
    {
        public Guid AdotanteId { get; set; }
        public Guid PetId { get; set; }

        public Adotante Adotante { get; set; }
        public Pet Pet { get; set; }
    }
}

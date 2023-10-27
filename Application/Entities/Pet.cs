using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Pet
    {
        public Guid PetId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<string> Fotos { get; set; }
        public bool EhDog { get; set; }
        public List<string> Caracteristicas { get; set; }
        public List<Guid> AdotantesFavoritos { get; set; }

    }
}

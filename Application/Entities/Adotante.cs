using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public abstract class Adotante : Account
    {

        public string CPF { get; set; }
        public List<string> Fotos { get; set; }
        public List<Guid> PetsFavoritos { get; set; }

    }
}

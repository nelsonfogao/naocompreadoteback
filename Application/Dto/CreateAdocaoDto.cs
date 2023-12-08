using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateAdocaoDto
    {
        public Guid AdotanteId { get; set; }
        public Guid PetId { get; set; }
    }
}

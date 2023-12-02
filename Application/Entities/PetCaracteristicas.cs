using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class PetCaracteristicas
    {
        [Key]
        public Guid PetId { get; set; }
        public Guid CaracteristicaId { get; set; }
    }
}

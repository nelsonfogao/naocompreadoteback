using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class FotosPets
    {
        [Key]
        public Guid IdFoto { get; set; }
        public Guid PetId { get; set; }
        public string Link { get; set; }

        [JsonIgnore]
        public virtual Pet Pet { get; set; }
    }
}

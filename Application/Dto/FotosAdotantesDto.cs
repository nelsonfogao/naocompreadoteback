using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class FotosAdotantesDto
    {
        public Guid IdFoto { get; set; }
        public Guid AdotanteId { get; set; }
        public string Link { get; set; }

        [JsonIgnore]
        public AdotanteDto Adotante { get; set; }
    }
}

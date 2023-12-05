﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class FotosAdotantes
    {
        [Key]
        public Guid IdFoto { get; set; }
        public Guid AdotanteId { get; set; }
        public string Link { get; set; }

        [JsonIgnore]
        public virtual Adotante Adotante { get; set; }
    }
}
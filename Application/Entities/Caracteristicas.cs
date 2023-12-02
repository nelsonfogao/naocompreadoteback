using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Caracteristicas
    {
        [Key]
        public int IdCaracteristica { get; set; }
        public string Nome { get; set; }
    }
}

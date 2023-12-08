using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Pet
    {
        [Key]
        public Guid PetId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool EhDog { get; set; }
        public Guid DoadorId { get; set; }
        public bool Disponivel { get; set; }
        public virtual IList<FotosPets> FotosPet { get; set; }
        public virtual IList<Caracteristicas> Caracteristicas { get; set; }
        [JsonIgnore]
        public virtual Doador Doador { get; set; }

        public virtual IList<Adocoes> Adocoes { get; set; }

    }
}

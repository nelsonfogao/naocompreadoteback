using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public abstract class Doador: Account
    {
        public List<Pet> Pets { get; set; }


    }
}

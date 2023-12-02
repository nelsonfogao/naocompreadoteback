using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class AdotanteMap: IEntityTypeConfiguration<Adotante>
    {
        public void Configure(EntityTypeBuilder<Adotante> builder)
        {
            builder.ToTable("Adotantes");
            builder.HasKey(x => x.AdotanteId);
            builder.Property(x=>x.AdotanteId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome);
            builder.Property(x => x.Endereco);
            builder.Property(x => x.Email);
            builder.Property(x => x.CPF);
            builder.HasMany<FotosAdotantes>(x => x.FotosAdotantes).WithOne(j=>j.Adotante).HasForeignKey(j=>j.IdFoto);
        }
    }
}

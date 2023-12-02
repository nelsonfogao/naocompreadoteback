using Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");
            builder.HasKey(x => x.PetId);
            builder.Property(x => x.PetId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome);
            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.EhDog);
            builder.Property(x=>x.DoadorId);
            builder.HasMany<FotosPets>(x => x.FotosPet).WithOne(b=>b.Pet).HasForeignKey(j=>j.IdFoto);
            builder.HasMany<Caracteristicas>(x => x.Caracteristicas);
            builder
                .HasOne<Doador>(a => a.Doador)
                .WithMany(p => p.Pets);
        }
    }
}
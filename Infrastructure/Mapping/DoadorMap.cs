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
    public class DoadorMap : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.ToTable("Doadores");
            builder.HasKey(x => x.DoadorId);
            builder.Property(x => x.DoadorId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome);
            builder.Property(x => x.Email);
            builder.Property(x => x.Endereco);
            builder.HasMany<Pet>(x => x.Pets);
        }
    }
}
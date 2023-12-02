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
    public class AdocoesMap : IEntityTypeConfiguration<Adocoes>
    {
        public void Configure(EntityTypeBuilder<Adocoes> builder)
        {
            builder.ToTable("Adocoes");

            builder
                .HasKey(a => new { a.AdotanteId, a.PetId });

            builder
                .HasOne(a => a.Adotante)
                .WithMany(ad => ad.Adocoes)
                .HasForeignKey(a => a.AdotanteId);

            builder
                .HasOne(a => a.Pet)
                .WithMany(p => p.Adocoes)
                .HasForeignKey(a => a.PetId);

        }
    }
}

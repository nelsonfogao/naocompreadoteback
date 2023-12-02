
using Application.Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Data
{
    public class WebApiContext : DbContext
    {
        public DbSet<Adotante> Adotantes { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<FotosAdotantes> FotosAdotantes { get; set; }
        public DbSet<FotosPets> FotosPets { get; set; }

        public DbSet<Adocoes> Adocoes { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdocoesMap());
            modelBuilder.ApplyConfiguration(new AdotanteMap());
            modelBuilder.ApplyConfiguration(new DoadorMap());
            modelBuilder.ApplyConfiguration(new PetMap());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NELSON\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}

using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Repositories
{
    public class OracleDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InscritoLote>().Property(x => x.Id).IsUnicode(false);
            modelBuilder.Entity<InscritoPueblo>().Property(x => x.Id).IsUnicode(false);
            modelBuilder.Entity<InscritoCalle>().Property(x => x.Id).IsUnicode(false);
            modelBuilder.Entity<InscritoManzana>().Property(x => x.Id).IsUnicode(false);

            modelBuilder.Entity<MatrizPueblo>().Property(x => x.Id).IsUnicode(false);
        }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Lote> SFI_GEOLOTE { get; set; }
        public DbSet<Calle> SFI_GEOCALLE { get; set; }
        public DbSet<Manzana> SFI_GEOMANZANA { get; set; }
        public DbSet<Pueblo> SFI_GEOPUEBLO { get; set; }
        public DbSet<UnidadT> SFI_GEOUNIDADT { get; set; }
        public DbSet<PuebloInforme> SFI_PUEBLO_INFORME { get; set; }

        public DbSet<InscritoLote> BMAP_LOTE { get; set; }
        public DbSet<InscritoCalle> BMAP_CALLE { get; set; }
        public DbSet<InscritoManzana> BMAP_MANZANA { get; set; }
        public DbSet<InscritoPueblo> BMAP_PUEBLO { get; set; }

        public DbSet<MatrizPueblo> BMAP_MATRIZ { get; set; }

        public DbSet<baseDistrito> BMAP_DISTRITO { get; set; }
        public DbSet<baseProvincia> BMAP_PROVINCIA { get; set; }
        public DbSet<baseRegion> BMAP_DEPARTAMENTO { get; set; }
    }

    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<baseCentroide> SFI_CENTROIDE { get; set; }
    }
}

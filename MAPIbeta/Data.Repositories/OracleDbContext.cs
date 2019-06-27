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
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Lote> SFI_GEOLOTE { get; set; }
        public DbSet<Calle> SFI_GEOCALLE { get; set; }
        public DbSet<Manzana> SFI_GEOMANZANA { get; set; }
        public DbSet<Pueblo> SFI_GEOPUEBLO { get; set; }
        public DbSet<UnidadT> SFI_GEOUNIDADT { get; set; }
        public DbSet<Formalizacion> SFI_PUEBLOEXISTENTE { get; set; }
    }

    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Centroide> SFI_CENTROIDE { get; set; }
    }
}

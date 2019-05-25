using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Calle> Calles { get; set; }
        public DbSet<Manzana> Manzanas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Pueblo> Pueblos { get; set; }
        public DbSet<UnidadT> UnidadTs { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<FeatureCollection> FeatureCollection { get; set; }
    }
}

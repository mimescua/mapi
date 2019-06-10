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
        public DbSet<Lote> SFI_GEOLOTES { get; set; }
        public DbSet<Calle> SFI_GEOCALLES { get; set; }
        public DbSet<Manzana> SFI_GEOMANZANAS { get; set; }
        public DbSet<Parcela> SFI_GEOPARCELAS { get; set; }
        public DbSet<Pueblo> SFI_GEOPUEBLOS { get; set; }
        public DbSet<UnidadT> SFI_GEOUNIDADTS { get; set; }
        public DbSet<Features> SFI_GEOFEATURES { get; set; }
        //public DbSet<FeatureCollection> SFI_GEOFEATURECOLLECTION { get; set; }
    }
}

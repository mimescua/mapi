using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_UBIGEO")]
    public class baseCentroide
    {
        [Column("UBI_GEO")][Key]
        public string Id { get; set; }

        [Column("UBI_LONGITUD")]
        public string Longitud { get; set; }
        [Column("UBI_LATITUD")]
        public string Latitud { get; set; }

        [Column("UBI_DISTRITO")]
        public string Distrito { get; set; }
        [Column("UBI_PROVINCIA")]
        public string Provincia { get; set; }
        [Column("UBI_DEPARTAMENTO")]
        public string Region { get; set; }
    }
}
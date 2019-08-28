using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_DISTRITO")]
    public class baseDistrito
    {
        [Column("IDDIST")][Key]
        public string Id { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string CoordinateString { get; set; }
        [NotMapped]
        public List<List<List<List<double>>>> Coordinates { get; set; }

        //[Column("UBI_DISTRITO")]
        //public string Distrito { get; set; }
        //[Column("UBI_PROVINCIA")]
        //public string Provincia { get; set; }
        //[Column("UBI_DEPARTAMENTO")]
        //public string Region { get; set; }
    }
}
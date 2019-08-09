﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_PROVINCIA")]
    public class baseProvincia
    {
        [Column("IDPROV")][Key]
        public string Id { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        //[Column("UBI_PROVINCIA")]
        //public string Provincia { get; set; }
        //[Column("UBI_DEPARTAMENTO")]
        //public string Region { get; set; }
    }
}
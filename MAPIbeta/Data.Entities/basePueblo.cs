﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_PUEBLO")]
    public class basePueblo
    {
        [Column("OID")][Key]
        public string Id { get; set; }

        public List<baseCalle> Calles { get; set; }
        public List<baseLote> Lotes { get; set; }
        public List<baseManzana> Manzanas { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        [NotMapped]
        public float[][] Coords { get; set; }
        //public List<List<float>> Coords { get; set; }

        [Column("NOM_PUEBLO")]
        public string Nombre { get; set; }
        [Column("ID_DIST")]
        public string Ubigeo { get; set; }

        [Column("ID_PUEBLO")]
        public string CodPueblo { get; set; }
        [Column("ID_PLANO")]
        public string NroPlano { get; set; }
        [Column("FECH_TRAN")]
        public string Fecha { get; set; }
        [Column("TABLE_SRC")]
        public string Fuente { get; set; }
    }
}
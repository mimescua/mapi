﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_LOTE")]
    public class baseLote
    {
        [Column("OID")][Key]
        public string Id { get; set; }

        [Column("ID_PUEBLO")]
        public string CodPueblo { get; set; }
        public basePueblo Pueblo { get; set; }

        [Column("NRO_MZNA")]
        public string ManzanaId { get; set; }
        public baseManzana Manzana { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        [Column("NRO_LOTE")]
        public string Nombre { get; set; }
        [Column("ID_DIST")]
        public string Ubigeo { get; set; }

        [Column("ID_PLANO")]
        public string NroPlano { get; set; }
        [Column("FECH_TRAN")]
        public string Fecha { get; set; }
        [Column("TABLE_SRC")]
        public string Fuente { get; set; }
    }
}

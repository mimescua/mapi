using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_CALLE")]
    public class InscritoCalle
    {
        [Column("OID")][Key]
        public string Id { get; set; }

        [Column("ID_PUEBLO")]
        public string CodPueblo { get; set; }
        public InscritoPueblo Pueblo { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string CoordinateString { get; set; }
        [NotMapped]
        public List<double> Coordinates { get; set; }

        [Column("NOM_CALLE")]
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

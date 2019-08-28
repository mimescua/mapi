using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_CP_PBL")]
    public class MatrizPueblo
    {
        [Column("OID")][Key]
        public string Id { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string CoordinateString { get; set; }
        [NotMapped]
        public List<List<List<List<double>>>> Coordinates { get; set; }

        [Column("TEXT")]
        public string Nombre { get; set; }
        [Column("IDDIST")]
        public string Ubigeo { get; set; }

        [Column("CODPBL")]
        public string CodPueblo { get; set; }
    }
}

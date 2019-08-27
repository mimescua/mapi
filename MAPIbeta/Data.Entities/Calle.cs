using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOCALLE")]
    public class Calle
    {
        [Column("CALLEID")][Key]
        public int Id { get; set; }

        [Column("PUEBLOID")]
        public int PuebloId { get; set; }
        public Pueblo Pueblo { get; set; }

        [Column("TYPE")]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string CoordinateString { get; set; }
        [NotMapped]
        public List<double?> Coordinates { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("UBIGEO")]
        public string Ubigeo { get; set; }
    }
}

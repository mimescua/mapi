using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOUNIDADTS")]//[Table("UNIDADTS")]
    public class UnidadT
    {
        [Column("UNIDADTID")][Key]
        public int Id { get; set; }

        //public List<Pueblo> Pueblos { get; set; }

        [Column("TYPE")]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("UBIGEO")]
        public string Ubigeo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOMANZANA")]//[Table("MANZANAS")]
    public class Manzana
    {
        [Column("MANZANAID")][Key]//[Column("ID")][Key]
        public int Id { get; set; }

        public List<Calle> Calles { get; set; }
        public List<Lote> Lotes { get; set; }

        [Column("PUEBLOID")]
        public int PuebloId { get; set; }
        public Pueblo Pueblo { get; set; }

        [Column("TYPE")]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("UBIGEO")]
        public string Ubigeo { get; set; }
        [Column("CANTLOTES")]
        public int CantLotes { get; set; }
        [Column("AREA")]
        public double Area { get; set; }
        //public string TipoUso { get; set; }
    }
}

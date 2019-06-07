using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOPARCELAS")]//[Table("PARCELAS")]
    public class Parcela
    {
        [Column("PARCELAID")][Key]//[Column("ID")][Key]
        public int Id { get; set; }

        [Column("GEA_ID")]
        public int ArchivoId { get; set; }

        public List<Manzana> Manzanas { get; set; }
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
        //public int CantManzanas { get; set; }
        [Column("AREA")]
        public double Area { get; set; }
    }
}

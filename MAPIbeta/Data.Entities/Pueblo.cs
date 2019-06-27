using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOPUEBLO")]//[Table("PUEBLOS")]
    public class Pueblo
    {
        [Column("PUEBLOID")][Key]//[Column("ID")][Key]
        public int Id { get; set; }

        public List<Manzana> Manzanas { get; set; }

        [Column("TYPE")]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("UBIGEO")]
        public string Ubigeo { get; set; }
        [Column("NOMPARCELA")]
        public string NomParcela { get; set; }
        [Column("AREA")]
        public double Area { get; set; }//AreaBruta

        [Column("AREAVIVIENDA")]
        public double AreaVivienda { get; set; }
        [Column("AREACOMUNAL")]
        public double AreaComunal { get; set; }
        [Column("AREAEDUCACION")]
        public double AreaEducacion { get; set; }
    }
}

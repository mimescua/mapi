using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOLOTES")]//[Table("LOTES")]
    public class Lote
    {
        [Column("LOTEID")][Key]//[Column("ID")][Key]
        public int Id { get; set; }

        [Column("GEA_ID")]
        public int ArchivoId { get; set; }

        [Column("PUEBLOID")]
        public int PuebloId { get; set; }
        public Pueblo Pueblo { get; set; }

        [Column("MANZANAID")]
        public int ManzanaId { get; set; }
        public Manzana Manzana { get; set; }

        [Column("TYPE")]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string Coordinates { get; set; }
        //public OracleLob Coordinates { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("UBIGEO")]
        public string Ubigeo { get; set; }
        [Column("AREA")]
        public double Area { get; set; }

        [Column("TIPOUSO")]
        public string TipoUso { get; set; }
        [Column("MEDIDFRNT")]
        public string MedidFrnt { get; set; }//double to list?
        [Column("MEDIDIZQ")]
        public string MedidIzq { get; set; }
        [Column("MEDIDPOST")]
        public string MedidPost { get; set; }
        [Column("MEDIDDER")]
        public string MedidDer { get; set; }
        [Column("COLINFRNT")]
        public string ColinFrnt { get; set; }
        [Column("COLINIZQ")]
        public string ColinIzq { get; set; }
        [Column("COLINPOST")]
        public string ColinPost { get; set; }
        [Column("COLINDER")]
        public string ColinDer { get; set; }
    }
}

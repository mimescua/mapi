using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("BMAP_PUEBLO")]
    public class InscritoPueblo
    {
        [Column("OID")][Key]
        public string Id { get; set; }

        public List<InscritoCalle> Calles { get; set; }
        public List<InscritoLote> Lotes { get; set; }
        public List<InscritoManzana> Manzanas { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [Column("COORDINATES")]
        public string CoordinateString { get; set; }
        [Column("CENTROID")]
        public string Centroide { get; set; }/////

        [NotMapped]
        public List<List<List<List<double?>>>> Coordinates { get; set; }
        //public JArray Coords { get; set; }

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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("FEATURES")]
    public class Features
    {
        [Column("ID")][Key]
        public int Id { get; set; }
        [Column("FKEY")]
        public int fkey { get; set; }
        [Column("TYPE")]
        public string Type { get; set; }
        [Column("FEATURECOLLECTIONID")]
        public int FeatureCollectionId { get; set; }
        public FeatureCollection FeatureCollection { get; set; }
        //[Column("LOTEPROPID")]
        //public int LotePropId { get; set; }
        //public Lote LoteProp { get; set; }
        //[Column("LOTEGEOMID")]
        //public int LoteGeomId { get; set; }
        //public Lote LoteGeom { get; set; }
        //[Column("CALLEPROPID")]
        //public int CallePropId { get; set; }
        //public Calle CalleProp { get; set; }
        //[Column("CALLEGEOMID")]
        //public int CalleGeomId { get; set; }
        //public Calle CalleGeom { get; set; }
        //[Column("MANZANAPROPID")]
        //public int ManzanaPropId { get; set; }
        //public Manzana ManzanaProp { get; set; }
        //[Column("MANZANAGEOMID")]
        //public int ManzanaGeomId { get; set; }
        //public Manzana ManzanaGeom { get; set; }
        //[Column("PARCELAPROPID")]
        //public int ParcelaPropId { get; set; }
        //public Parcela ParcelaProp { get; set; }
        //[Column("PARCELAGEOMID")]
        //public int ParcelaGeomId { get; set; }
        //public Parcela ParcelaGeom { get; set; }
        //[Column("PUEBLOPROPID")]
        //public int PuebloPropId { get; set; }
        //public Pueblo PuebloProp { get; set; }
        //[Column("PUEBLOGEOMID")]
        //public int PuebloGeomId { get; set; }
        //public Pueblo PuebloGeom { get; set; }
        //[Column("UNIDADTPROPID")]
        //public int UnidadTPropId { get; set; }
        //public UnidadT UnidadTProp { get; set; }
        //[Column("UNIDADTGEOMID")]
        //public int UnidadTGeomId { get; set; }
        //public UnidadT UnidadTGeom { get; set; }
    }
}

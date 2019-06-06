using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEOFEATURES")]//[Table("FEATURES")]
    public class Features
    {
        [Column("FEATUREID")][Key]//[Column("ID")][Key]
        public int Id { get; set; }
        //[Column("FKEY")]
        //public int fkey { get; set; }
        [Column("TYPE")]
        public string Type { get; set; }
        [NotMapped]//[Column("FEATURECOLLECTIONID")]
        public int FeatureCollectionId { get; set; }
        public FeatureCollection FeatureCollection { get; set; }
    }
}

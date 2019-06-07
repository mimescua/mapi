using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [NotMapped]//[Table("SFI_GEOFEATURECOLLECTION")]//[Table("FEATURECOLLECTION")]
    public class FeatureCollection
    {
        [NotMapped]//[Column("FEATURECOLLECTIONID")][Key]
        public int Id { get; set; }
        [NotMapped]//[Column("TYPE")]
        public string Type { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]//[Column("FEATURES")]
        public List<Features> Features { get; set; }
    }
}

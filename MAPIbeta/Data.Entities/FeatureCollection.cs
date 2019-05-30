using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("FEATURECOLLECTION")]
    public class FeatureCollection
    {
        [Column("ID")][Key]
        public int Id { get; set; }
        [Column("TYPE")]
        public string Type { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [Column("FEATURES")]
        public List<Features> Features { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [NotMapped]
    public class FeatureCollection
    {
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public string Type { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public List<Features> Features { get; set; }
    }
}

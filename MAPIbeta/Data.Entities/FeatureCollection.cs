using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class FeatureCollection
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Features> Features { get; set; }
    }
}

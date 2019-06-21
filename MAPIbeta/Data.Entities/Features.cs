using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [NotMapped]
    public class Features
    {
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public string Type { get; set; }
    }
}

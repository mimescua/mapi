using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_GEO_PLANO")]
    public class Plano
    {
        [Column("PLA_ID")][Key]
        public int Id { get; set; }
        [Column("PLA_NUM_PLANO")]
        public string NroPlano { get; set; }
        [Column("PLA_ESTADO")]
        public string Estado { get; set; }
    }
}

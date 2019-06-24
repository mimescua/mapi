using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SFI_PUEBLO")]
    public class Formalizacion
    {
        [Column("PUE_CODPUEBLO")][Key]
        public int Id { get; set; }

        [Column("PUE_COORDENADA")]
        public string Coordenadas { get; set; }

        [Column("PUE_PUEBLO_CAMPO")]
        public string Nombre { get; set; }

        [Column("PUE_ESTADO")]
        public int Estado { get; set; }

        [Column("PUE_IND_TIPO")]
        public int Tipo { get; set; }
    }
}
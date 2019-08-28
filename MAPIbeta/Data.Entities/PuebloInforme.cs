using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    //Coordenadas de ubicación de pueblo en formalización
    [Table("SFI_PUEBLO")]
    public class PuebloInforme
    {
        [Column("PUE_CODPUEBLO")][Key]
        public int Id { get; set; }

        [Column("PUE_PUEBLO_CAMPO")]
        public string Nombre { get; set; }

        [Column("PUE_COD_COFOPRI")]
        public string CodCofopri { get; set; }

        [Column("PUE_COORDENADA")]
        public string Coordinates { get; set; }


        //Usado solo para validar queries
        [Column("PUE_ESTADO")]
        public int Estado { get; set; }

        [Column("PUE_IND_TIPO")]
        public int Tipo { get; set; }
    }
}
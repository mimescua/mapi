using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Manzana
    {
        public int Id { get; set; }

        public List<Calle> Calles { get; set; }
        public List<Manzana> Manzanas { get; set; }
        public Parcela Parcela { get; set; }
        public int ParcelaId { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
        public int CantLotes { get; set; }
        public double Area { get; set; }
        //public string TipoUso { get; set; }
    }
}

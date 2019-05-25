using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Parcela
    {
        public int Id { get; set; }

        public List<Manzana> Manzanas { get; set; }
        public Pueblo Pueblo { get; set; }
        public int PuebloId { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
        //public int CantManzanas { get; set; }
        public double Area { get; set; }
    }
}

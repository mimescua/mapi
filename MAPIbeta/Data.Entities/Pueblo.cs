using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Pueblo
    {
        public int Id { get; set; }

        public List<Manzana> Manzanas { get; set; }
        public List<Parcela> Parcelas { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
        public int CantParcelas { get; set; }
        public double Area { get; set; }//AreaBruta

        public int AreaVivienda { get; set; }
        public int AreaComunal { get; set; }
        public int AreaEducacion { get; set; }
    }
}

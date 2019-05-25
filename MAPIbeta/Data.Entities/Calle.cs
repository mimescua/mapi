using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Calle
    {
        public int Id { get; set; }

        public Lote Lote { get; set; }
        public int LoteId { get; set; }
        public Manzana Manzana { get; set; }
        public int ManzanaId { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
    }
}

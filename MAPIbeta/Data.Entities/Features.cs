using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Features
    {
        public int Id { get; set; }
        public int _fkey { get; set; }
        public string Type { get; set; }
        public Lote LoteProp { get; set; }
        public Lote LoteGeom { get; set; }
        public Calle CalleProp { get; set; }
        public Calle CalleGeom { get; set; }
        public Manzana ManzanaProp { get; set; }
        public Manzana ManzanaGeom { get; set; }
        public Parcela ParcelaProp { get; set; }
        public Parcela ParcelaGeom { get; set; }
        public Pueblo PuebloProp { get; set; }
        public Pueblo PuebloGeom { get; set; }
        public UnidadT UnidadTProp { get; set; }
        public UnidadT UnidadTGeom { get; set; }
    }
}

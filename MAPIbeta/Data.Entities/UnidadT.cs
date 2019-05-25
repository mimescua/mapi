using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UnidadT
    {
        public int Id { get; set; }

        public List<Pueblo> Pueblos { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
    }
}

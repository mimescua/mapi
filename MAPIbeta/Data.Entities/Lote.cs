using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Lote
    {
        public int Id { get; set; }

        public Calle Calle { get; set; }
        public int CalleId { get; set; }
        public Manzana Manzana { get; set; }
        public int ManzanaId { get; set; }

        public string Type { get; set; }
        public string Coordinates { get; set; }
        //public OracleLob Coordinates { get; set; }

        public string Nombre { get; set; }
        public int Ubigeo { get; set; }
        public double Area { get; set; }

        public string TipoUso { get; set; }
        public string MedidFrnt { get; set; }//double to list?
        public string MedidIzq { get; set; }
        public string MedidPost { get; set; }
        public string MedidDer { get; set; }
        public string ColinFrnt { get; set; }
        public string ColinIzq { get; set; }
        public string ColinPost { get; set; }
        public string ColinDer { get; set; }
    }
}

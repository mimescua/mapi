using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class LotePropertyType : ObjectGraphType<Lote>
    {
        public LotePropertyType()
        {
            Name = "properties";
            Field(x => x.Id).Description("Identificador del lote");
            Field(x => x.Nombre).Description("Nombre del lote");
            Field(x => x.Ubigeo).Description("Ubigeo del lote");
            Field(x => x.Area).Description("Área del lote");
            Field(x => x.TipoUso).Description("Tipo de uso del lote");
            Field(x => x.MedidFrnt).Description("Medida frontal del lote");
            Field(x => x.MedidIzq).Description("Medida izquierda del lote");
            Field(x => x.MedidPost).Description("Medida posterior del lote");
            Field(x => x.MedidDer).Description("Medida derecha del lote");
            Field(x => x.ColinFrnt).Description("Colindancia frontal del lote");
            Field(x => x.ColinIzq).Description("Colindancia izquierda del lote");
            Field(x => x.ColinPost).Description("Colindancia posterior del lote");
            Field(x => x.ColinDer).Description("Colindancia derecha del lote");
        }
    }
}

using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class LoteGeometryType : ObjectGraphType<Lote>
    {
        public LoteGeometryType()
        {
            Name = "geometryy";
            Field(x => x.Type).Description("Tipo de geometría del lote");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class LotePropertyType : ObjectGraphType<Lote>
    {
        public LotePropertyType()
        {
            Name = "loteProperties";
            Field(x => x.Id).Description("Identificador del lote");
            Field(x => x.Nombre, nullable: true).Description("Nombre del lote");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo del lote");
            Field(x => x.Area, nullable: true).Description("Área del lote");
            Field(x => x.TipoUso, nullable: true).Description("Tipo de uso del lote");
            Field(x => x.MedidFrnt, nullable: true).Description("Medida frontal del lote");
            Field(x => x.MedidIzq, nullable: true).Description("Medida izquierda del lote");
            Field(x => x.MedidPost, nullable: true).Description("Medida posterior del lote");
            Field(x => x.MedidDer, nullable: true).Description("Medida derecha del lote");
            Field(x => x.ColinFrnt, nullable: true).Description("Colindancia frontal del lote");
            Field(x => x.ColinIzq, nullable: true).Description("Colindancia izquierda del lote");
            Field(x => x.ColinPost, nullable: true).Description("Colindancia posterior del lote");
            Field(x => x.ColinDer, nullable: true).Description("Colindancia derecha del lote");
        }
    }
}

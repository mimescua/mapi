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
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del lote");
            Field(x => x.Coordinates).Description("Geometría del lote");
        }
    }
}

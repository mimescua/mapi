using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class UnidadTGeometryType : ObjectGraphType<UnidadT>
    {
        public UnidadTGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la unidad territorial");
            Field(x => x.Coordinates).Description("Geometría de la unidad territorial");
        }
    }
}

using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class CalleGeometryType : ObjectGraphType<Calle>
    {
        public CalleGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la calle");
            Field(x => x.Coordinates).Description("Geometría de la calle");
        }
    }
}

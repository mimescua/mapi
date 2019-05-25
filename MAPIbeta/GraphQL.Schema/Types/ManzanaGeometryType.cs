using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class ManzanaGeometryType : ObjectGraphType<Manzana>
    {
        public ManzanaGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la manzana");
            Field(x => x.Coordinates).Description("Geometría de la manzana");
        }
    }
}

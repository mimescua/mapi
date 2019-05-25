using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class PuebloGeometryType : ObjectGraphType<Pueblo>
    {
        public PuebloGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field(x => x.Coordinates).Description("Geometría del pueblo");
        }
    }
}

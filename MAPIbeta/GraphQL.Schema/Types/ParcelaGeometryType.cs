using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class ParcelaGeometryType : ObjectGraphType<Parcela>
    {
        public ParcelaGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la parcela");
            Field(x => x.Coordinates).Description("Geometría de la parcela");
        }
    }
}

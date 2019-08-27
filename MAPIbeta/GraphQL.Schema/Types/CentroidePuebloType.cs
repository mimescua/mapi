using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class CentroidePuebloGeometryType : ObjectGraphType<Pueblo>
    {
        public CentroidePuebloGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class CentroidePuebloPropertyType : ObjectGraphType<Pueblo>
    {
        public CentroidePuebloPropertyType()
        {
            Name = "Pueblo_Tematico_Properties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre).Description("Nombre del pueblo");
        }
    }
}
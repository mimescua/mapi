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
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class CallePropertyType : ObjectGraphType<Calle>
    {
        public CallePropertyType()
        {
            Name = "calleProperties";
            Field(x => x.Id).Description("Identificador de la calle");
            Field(x => x.Nombre, nullable: true).Description("Nombre de la calle");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la calle");
        }
    }
}

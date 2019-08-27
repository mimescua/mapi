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
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class ManzanaPropertyType : ObjectGraphType<Manzana>
    {
        public ManzanaPropertyType()
        {
            Name = "manzanaProperties";
            Field(x => x.Id).Description("Identificador de la manzana");
            Field(x => x.Nombre, nullable: true).Description("Nombre de la manzana");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la manzana");
            Field(x => x.CantLotes, nullable: true).Description("Cantidad de lotes en la manzana");
            Field(x => x.Area, nullable: true).Description("Área de la manzana");
        }
    }
}

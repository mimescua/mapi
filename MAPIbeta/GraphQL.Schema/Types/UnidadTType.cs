using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class UnidadTType : ObjectGraphType<UnidadT>
    {
        public UnidadTType()
        {
            Name = "unidadt";
            Field(x => x.Id).Description("Identificador de la unidad territorial");
            Field(x => x.Type).Description("Tipo de geometría de la unidad territorial");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
            Field(x => x.Nombre, nullable: true).Description("Nombre de la unidad territorial");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la unidad territorial");
        }
    }
    public class UnidadTGeometryType : ObjectGraphType<UnidadT>
    {
        public UnidadTGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la unidad territorial");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class UnidadTPropertyType : ObjectGraphType<UnidadT>
    {
        public UnidadTPropertyType()
        {
            Name = "unidadtProperties";
            Field(x => x.Id).Description("Identificador de la unidad territorial");
            Field(x => x.Nombre, nullable: true).Description("Nombre de la unidad territorial");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la unidad territorial");
        }
    }
}

using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class MatrizPuebloGeometryType : ObjectGraphType<MatrizPueblo>
    {
        public MatrizPuebloGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class MatrizPuebloPropertyType : ObjectGraphType<MatrizPueblo>
    {
        public MatrizPuebloPropertyType()
        {
            Name = "Pueblo_Matriz_Properties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre, nullable: true).Description("Nombre del pueblo");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo del pueblo");

            Field(x => x.CodPueblo, nullable: true).Description("código del pueblo");
        }
    }
}

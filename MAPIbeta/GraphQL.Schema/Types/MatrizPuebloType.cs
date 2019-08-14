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
            Field(x => x.Coordinates).Description("Geometría del pueblo");
        }
    }
    public class MatrizPuebloPropertyType : ObjectGraphType<MatrizPueblo>
    {
        public MatrizPuebloPropertyType()
        {
            Name = "Pueblo_Matriz_Properties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre).Description("Nombre del pueblo");
            Field(x => x.Ubigeo).Description("Ubigeo del pueblo");

            Field(x => x.CodPueblo).Description("código del pueblo");
        }
    }
}

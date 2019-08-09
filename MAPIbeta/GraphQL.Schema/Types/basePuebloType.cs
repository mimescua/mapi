using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class basePuebloGeometryType : ObjectGraphType<basePueblo>
    {
        public basePuebloGeometryType()
        {
            Name = "geometryxd";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field(x => x.Coordinates).Description("Geometría del pueblo");
            Field(x => x.Coords).Description("Geometría del pueblo");

            //Field<ListGraphType<ListGraphType<DecimalGraphType>>>().Name("coordinates").ResolveAsync(async context => context.Source.Coords);
        }
    }
    public class basePuebloPropertyType : ObjectGraphType<basePueblo>
    {
        public basePuebloPropertyType()
        {
            Name = "bPuebloProperties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre).Description("Nombre del pueblo");
            Field(x => x.Ubigeo).Description("Ubigeo del pueblo");

            Field(x => x.CodPueblo).Description("código del pueblo");
            Field(x => x.NroPlano).Description("Número de plano de procedencia");
            Field(x => x.Fecha).Description("Fecha de registro");
            Field(x => x.Fuente).Description("Origen del registro geométrico");
        }
    }
}

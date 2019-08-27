using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class InscritoLoteGeometryType : ObjectGraphType<InscritoLote>
    {
        public InscritoLoteGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del lote");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class InscritoLotePropertyType : ObjectGraphType<InscritoLote>
    {
        public InscritoLotePropertyType()
        {
            Name = "Lote_Inscrito_Properties";
            Field(x => x.Id).Description("Ubigeo del lote");
            Field(x => x.Nombre, nullable: true).Description("Nombre del lote");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo del lote");

            Field(x => x.CodPueblo, nullable: true).Description("código del lote");
            Field(x => x.NroPlano, nullable: true).Description("Número de plano de procedencia");
            Field(x => x.Fecha, nullable: true).Description("Fecha de registro");
            Field(x => x.Fuente, nullable: true).Description("Origen del registro geométrico");
        }
    }
}

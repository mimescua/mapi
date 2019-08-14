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
            Field(x => x.Coordinates).Description("Geometría del lote");
        }
    }
    public class InscritoLotePropertyType : ObjectGraphType<InscritoLote>
    {
        public InscritoLotePropertyType()
        {
            Name = "Lote_Inscrito_Properties";
            Field(x => x.Id).Description("Ubigeo del lote");
            Field(x => x.Nombre).Description("Nombre del lote");
            Field(x => x.Ubigeo).Description("Ubigeo del lote");

            Field(x => x.CodPueblo).Description("código del lote");
            Field(x => x.NroPlano).Description("Número de plano de procedencia");
            Field(x => x.Fecha).Description("Fecha de registro");
            Field(x => x.Fuente).Description("Origen del registro geométrico");
        }
    }
}

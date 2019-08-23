using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class InscritoCalleGeometryType : ObjectGraphType<InscritoCalle>
    {
        public InscritoCalleGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la calle");
            Field(x => x.Coordinates).Description("Geometría del lote");
        }
    }
    public class InscritoCallePropertyType : ObjectGraphType<InscritoCalle>
    {
        public InscritoCallePropertyType()
        {
            Name = "Calle_Inscrito_Properties";
            Field(x => x.Id).Description("Ubigeo de la calle");
            Field(x => x.Nombre, nullable: true).Description("Nombre de la calle");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la calle");

            Field(x => x.CodPueblo, nullable: true).Description("código de la calle");
            Field(x => x.NroPlano, nullable: true).Description("Número de plano de procedencia");
            Field(x => x.Fecha, nullable: true).Description("Fecha de registro");
            Field(x => x.Fuente, nullable: true).Description("Origen del registro geométrico");
        }
    }
}

using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class InscritoManzanaGeometryType : ObjectGraphType<InscritoManzana>
    {
        public InscritoManzanaGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la manzana");
            Field(x => x.Coordinates).Description("Geometría de la manzana");
        }
    }
    public class InscritoManzanaPropertyType : ObjectGraphType<InscritoManzana>
    {
        public InscritoManzanaPropertyType()
        {
            Name = "Manzana_Inscrito_Properties";
            Field(x => x.Id).Description("Ubigeo de la manzana");
            Field(x => x.Nombre).Description("Nombre de la manzana");
            Field(x => x.Ubigeo).Description("Ubigeo de la manzana");

            Field(x => x.CodPueblo).Description("código de la manzana");
            Field(x => x.NroPlano).Description("Número de plano de procedencia");
            Field(x => x.Fecha).Description("Fecha de registro");
            Field(x => x.Fuente).Description("Origen del registro geométrico");
        }
    }
}

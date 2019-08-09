using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class baseManzanaGeometryType : ObjectGraphType<baseManzana>
    {
        public baseManzanaGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la manzana");
            Field(x => x.Coordinates).Description("Geometría de la manzana");
        }
    }
    public class baseManzanaPropertyType : ObjectGraphType<baseManzana>
    {
        public baseManzanaPropertyType()
        {
            Name = "bManzanaProperties";
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

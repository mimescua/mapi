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
            Field(x => x.Nombre, nullable: true).Description("Nombre de la manzana");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo de la manzana");

            Field(x => x.CodPueblo, nullable: true).Description("código de la manzana");
            Field(x => x.NroPlano, nullable: true).Description("Número de plano de procedencia");
            Field(x => x.Fecha, nullable: true).Description("Fecha de registro");
            Field(x => x.Fuente, nullable: true).Description("Origen del registro geométrico");
        }
    }
}

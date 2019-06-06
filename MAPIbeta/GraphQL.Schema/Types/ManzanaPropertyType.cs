using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class ManzanaPropertyType : ObjectGraphType<Manzana>
    {
        public ManzanaPropertyType()
        {
            Name = "manzanaProperties";
            Field(x => x.Id).Description("Identificador de la manzana");
            Field(x => x.Nombre).Description("Nombre de la manzana");
            Field(x => x.Ubigeo).Description("Ubigeo de la manzana");
            Field(x => x.CantLotes).Description("Cantidad de lotes en la manzana");
            Field(x => x.Area).Description("Área de la manzana");
        }
    }
}

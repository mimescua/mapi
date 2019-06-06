using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class UnidadTPropertyType : ObjectGraphType<UnidadT>
    {
        public UnidadTPropertyType()
        {
            Name = "unidadtProperties";
            Field(x => x.Id).Description("Identificador de la unidad territorial");
            Field(x => x.Nombre).Description("Nombre de la unidad territorial");
            Field(x => x.Ubigeo).Description("Ubigeo de la unidad territorial");
        }
    }
}

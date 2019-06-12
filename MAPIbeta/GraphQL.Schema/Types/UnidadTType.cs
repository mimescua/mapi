using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class UnidadTType : ObjectGraphType<UnidadT>
    {
        public UnidadTType()
        {
            Name = "unidadt";
            Field(x => x.Id).Description("Identificador de la unidad territorial");
            Field(x => x.Type).Description("Tipo de geometría de la unidad territorial");
            Field(x => x.Coordinates).Description("Geometría de la unidad territorial");
            Field(x => x.Nombre).Description("Nombre de la unidad territorial");
            Field(x => x.Ubigeo).Description("Ubigeo de la unidad territorial");
        }
    }
}

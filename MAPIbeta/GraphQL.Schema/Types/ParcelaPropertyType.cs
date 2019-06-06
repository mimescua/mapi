using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class ParcelaPropertyType : ObjectGraphType<Parcela>
    {
        public ParcelaPropertyType()
        {
            Name = "parcelaProperties";
            Field(x => x.Id).Description("Identificador de la parcela");
            Field(x => x.Nombre).Description("Nombre de la parcela");
            Field(x => x.Ubigeo).Description("Ubigeo de la parcela");
            Field(x => x.Area).Description("Área de la parcela");
        }
    }
}

using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class CallePropertyType : ObjectGraphType<Calle>
    {
        public CallePropertyType()
        {
            Name = "properties";
            Field(x => x.Id).Description("Identificador de la calle");
            Field(x => x.Nombre).Description("Nombre de la calle");
            Field(x => x.Ubigeo).Description("Ubigeo de la calle");
        }
    }
}

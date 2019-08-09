using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class CentroideType : ObjectGraphType<baseCentroide>
    {
        public CentroideType()
        {
            Name = "centroide";
            Field(x => x.Id).Description("Ubigeo - Identificador del centroide");
            Field(x => x.Longitud).Description("Longitud del centroide");
            Field(x => x.Latitud).Description("Latitud del centroide");
            Field(x => x.Distrito).Description("Distrito donde se ubica el centroide");
            Field(x => x.Provincia).Description("Provincia donde se ubica el centroide");
            Field(x => x.Region).Description("Region donde se ubica el centroide");
        }
    }
}
﻿using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class baseCalleGeometryType : ObjectGraphType<baseCalle>
    {
        public baseCalleGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la calle");
            Field(x => x.Coordinates).Description("Geometría del lote");
        }
    }
    public class baseCallePropertyType : ObjectGraphType<baseCalle>
    {
        public baseCallePropertyType()
        {
            Name = "bCalleProperties";
            Field(x => x.Id).Description("Ubigeo de la calle");
            Field(x => x.Nombre).Description("Nombre de la calle");
            Field(x => x.Ubigeo).Description("Ubigeo de la calle");

            Field(x => x.CodPueblo).Description("código de la calle");
            Field(x => x.NroPlano).Description("Número de plano de procedencia");
            Field(x => x.Fecha).Description("Fecha de registro");
            Field(x => x.Fuente).Description("Origen del registro geométrico");
        }
    }
}

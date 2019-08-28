using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class PuebloInformeType : ObjectGraphType<PuebloInforme>
    {
        public PuebloInformeType()
        {
            Name = "puebloInforme";
            Field(x => x.Id).Description("Identificador de pueblo existente");
            Field(x => x.Nombre).Description("Nombre de pueblo existente");
            Field(x => x.CodCofopri).Description("Nombre de pueblo existente");
            Field(x => x.Coordinates).Description("Coordenadas de pueblo existente");
        }
    }
}
using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class PuebloPropertyType : ObjectGraphType<Pueblo>
    {
        public PuebloPropertyType()
        {
            Name = "puebloProperties";
            Field(x => x.Id).Description("Identificador del pueblo");
            Field(x => x.Nombre).Description("Nombre del pueblo");
            Field(x => x.Ubigeo).Description("Ubigeo del pueblo");
            Field(x => x.CantParcelas).Description("Cantidad de parcelas en el pueblo");
            Field(x => x.Area).Description("Área del pueblo");
            Field(x => x.AreaVivienda).Description("Área del pueblo destinada a vivienda");
            Field(x => x.AreaComunal).Description("Área del pueblo destinada a área comunal");
            Field(x => x.AreaEducacion).Description("Área del pueblo destinada a educación");
        }
    }
}

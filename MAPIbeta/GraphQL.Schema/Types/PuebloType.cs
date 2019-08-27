using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class PuebloGeometryType : ObjectGraphType<Pueblo>
    {
        public PuebloGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field<StringGraphType>("coordinates",
              resolve: context => context.Source.Coordinates.ToArray());
        }
    }
    public class PuebloPropertyType : ObjectGraphType<Pueblo>
    {
        public PuebloPropertyType()
        {
            Name = "puebloProperties";
            Field(x => x.Id).Description("Identificador del pueblo");
            Field(x => x.Nombre, nullable: true).Description("Nombre del pueblo");
            Field(x => x.Ubigeo, nullable: true).Description("Ubigeo del pueblo");
            Field(x => x.NomParcela, nullable: true).Description("Nombre de parcela del pueblo");
            Field(x => x.Area, nullable: true).Description("Área del pueblo");
            Field(x => x.AreaVivienda, nullable: true).Description("Área del pueblo destinada a vivienda");
            Field(x => x.AreaComunal, nullable: true).Description("Área del pueblo destinada a área comunal");
            Field(x => x.AreaEducacion, nullable: true).Description("Área del pueblo destinada a educación");
        }
    }
}

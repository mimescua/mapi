using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class CentroideInscritoPuebloGeometryType : ObjectGraphType<InscritoPueblo>
    {
        public CentroideInscritoPuebloGeometryType()
        {
            Name = "geometryCen";
            Field(x => x.Type).Description("Tipo de geometría del pueblo");
            Field<StringGraphType>("centroide",
              resolve: context => context.Source.Centroide.ToArray());
        }
    }
    public class CentroideInscritoPuebloPropertyType : ObjectGraphType<InscritoPueblo>
    {
        public CentroideInscritoPuebloPropertyType()
        {
            Name = "Pueblo_Tematico_Properties";
            Field(x => x.Id).Description("Ubigeo del pueblo");
            Field(x => x.Nombre).Description("Nombre del pueblo");
        }
    }
}
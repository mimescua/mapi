using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class baseRegionGeometryType : ObjectGraphType<baseRegion>
    {
        public baseRegionGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la región");
            Field(x => x.Coordinates).Description("Geometría de la región");
        }
    }
    //public class baseRegionPropertyType : ObjectGraphType<baseDistrito>
    //{
    //    public baseRegionPropertyType()
    //    {
    //        Name = "bRegionProperties";
    //        Field(x => x.Id).Description("Ubigeo del distrito");
    //        Field(x => x.Region).Description("Nombre de la región");
    //    }
    //}
}

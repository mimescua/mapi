using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class baseProvinciaGeometryType : ObjectGraphType<baseProvincia>
    {
        public baseProvinciaGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría de la provincia");
            Field(x => x.Coordinates).Description("Geometría de la provincia");
        }
    }
    //public class baseProvinciaPropertyType : ObjectGraphType<baseDistrito>
    //{
    //    public baseProvinciaPropertyType()
    //    {
    //        Name = "bProvinciaProperties";
    //        Field(x => x.Id).Description("Ubigeo del distrito");
    //        Field(x => x.Provincia).Description("Nombre de la provincia");
    //        Field(x => x.Region).Description("Región de la provincia");
    //    }
    //}
}

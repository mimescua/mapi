using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class baseDistritoGeometryType : ObjectGraphType<baseDistrito>
    {
        public baseDistritoGeometryType()
        {
            Name = "geometry";
            Field(x => x.Type).Description("Tipo de geometría del distrito");
            Field(x => x.Coordinates).Description("Geometría del distrito");
        }
        //public baseDistritoPropertyType basees;

    }
    //public class baseDistritoPropertyType : ObjectGraphType<baseDistrito>
    //{
    //    public baseDistritoPropertyType()
    //    {
    //        Name = "bDistritoProperties";
    //        Field(x => x.Id).Description("Ubigeo del distrito");
    //        Field(x => x.Distrito).Description("Nombre del distrito");
    //        Field(x => x.Provincia).Description("Provincia del distrito");
    //        Field(x => x.Region).Description("Región del distrito");
    //    }
    //}
}
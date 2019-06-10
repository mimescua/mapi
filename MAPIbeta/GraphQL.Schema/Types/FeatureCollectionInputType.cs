using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeatureCollectionInputType : InputObjectGraphType
    {
        public FeatureCollectionInputType()
        {
            Name = "FeatureCollectionInput";
            Field<NonNullGraphType<IntGraphType>>("Id");
            Field<NonNullGraphType<StringGraphType>>("Type");
            Field<NonNullGraphType<StringGraphType>>("Nombre");
            Field<StringGraphType>("Features");
        }
    }
}
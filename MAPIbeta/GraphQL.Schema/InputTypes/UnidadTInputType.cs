using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.InputTypes
{
    public class UnidadTInputType : InputObjectGraphType
    {
        public UnidadTInputType()
        {
            Name = "unidadtInput";
            Field<NonNullGraphType<IntGraphType>>("Id");
            Field<NonNullGraphType<StringGraphType>>("Type");
            Field<NonNullGraphType<StringGraphType>>("Coordinates");
            Field<NonNullGraphType<StringGraphType>>("Nombre");
            Field<StringGraphType>("Ubigeo");
        }
    }
}
using Data.Repositories;
using GraphQL.Schema.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema
{
    public class mapiQuery : ObjectGraphType
    {
        public mapiQuery(GeoRepository geoRepository)
        {
            //Field<ListGraphType<FeatureCollectionType>>(
            //    "FeatureCollection",
            //    resolve: context => geoRepository.GetFeatureCollection()
            //);

            Field<FeatureCollectionType>(
                "FeatureCollection",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" }),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    return geoRepository.GetFeatureCollection(tipo);
                }
            );
        }
    }
}
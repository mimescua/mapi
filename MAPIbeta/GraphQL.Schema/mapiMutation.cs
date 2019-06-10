using Data.Repositories;
using GraphQL.Schema.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema
{
    public class mapiMutation : ObjectGraphType
    {
        public mapiMutation(GeoRepository geoRepository)
        {
            FieldAsync<FeatureCollectionType>(
                "crearUnidadTerritorial",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<FeatureCollectionInputType>> { Name = "FeatureCollection"}),
                resolve: async context =>
                {
                    var featurecollection = context.GetArgument<FeatureCollectionInputType>("FeatureCollection");
                    return await context.TryAsyncResolve(
                        async c => await GeoRepository.AddFeatureCollection(featurecollection));
                }
            );
        }
    }
}

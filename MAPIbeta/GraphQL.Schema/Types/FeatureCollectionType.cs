using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeatureCollectionType : ObjectGraphType<FeatureCollection>
    {
        public FeatureCollectionType(GeoRepository geoRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "FeatureCollection";
            Field(t => t.Type).Description("geometry collection type");
            Field(t => t.Name).Description("geometry collection name");
            Field<ListGraphType<FeaturesType>>(
                "Features",
                resolve: context =>
                {
                    //var user = (ClaimsPrincipal) context.UserContext;//securing this field
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Features>
                    (
                        "GetFeatureCollection", geoRepository.GetFeaturesForCollection
                    );
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}

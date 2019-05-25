using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeatureCollectionType : ObjectGraphType<FeatureCollection>
    {
        public FeatureCollectionType(GeoRepository geoRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "collection";
            Field(t => t.Type).Description("geometry type");
            Field<ListGraphType<FeaturesType>>(
                "Features",
                resolve: context =>
                {
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Features>
                    (
                        "GetLotsByLotId", geoRepository.GetFeaturesForCollection
                    );
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}

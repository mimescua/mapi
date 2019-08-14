using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeaturesMatrizType : ObjectGraphType<FeaturesMatriz>
    {
        public FeaturesMatrizType(ReadRepository readRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "featuresMATRIZ";
            Field(t => t.Type).Description("Feature type");
            Field<MatrizPuebloPropertyType, MatrizPueblo>().Name("puebloMATRIZProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, MatrizPueblo>("puebloMATRIZPropertiesPorId", readRepository.GetPropsPuebloMatrizByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<MatrizPuebloGeometryType, MatrizPueblo>().Name("puebloMATRIZGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, MatrizPueblo>("puebloMATRIZGeometryPorId", readRepository.GetGeomPuebloMatrizByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
        }
    }
}

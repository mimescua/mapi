using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeaturesTematicoType : ObjectGraphType<FeaturesTematico>
    {
        public FeaturesTematicoType(ReadRepository readRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "featuresTEMATICO";
            Field(t => t.Type).Description("Feature type");
            //Field<CentroidePuebloPropertyType, CentroidePueblo>().Name("puebloTEMATICOProperties").ResolveAsync(context =>
            //{
            //    var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, CentroidePueblo>("puebloTEMATICOPropertiesPorId", readRepository.GetPropsCenPueblosByIdList);
            //    return loader.LoadAsync(context.Source.Id.ToString());
            //});
            //Field<CentroidePuebloGeometryType, CentroidePueblo>().Name("puebloTEMATICOGeometry").ResolveAsync(context =>
            //{
            //    var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, CentroidePueblo>("puebloTEMATICOGeometryPorId", readRepository.GetGeomCenPueblosByIdList);
            //    return loader.LoadAsync(context.Source.Id.ToString());
            //});

            Field<CentroideInscritoPuebloPropertyType, InscritoPueblo>().Name("puebloInsTEMATICOProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoPueblo>("puebloInsTEMATICOPropertiesPorId", readRepository.GetPropsCenPueblosInscritoByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<CentroideInscritoPuebloGeometryType, InscritoPueblo>().Name("puebloInsTEMATICOGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoPueblo>("puebloInsTEMATICOGeometryPorId", readRepository.GetGeomCenPueblosInscritoByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

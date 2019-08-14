using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeaturesInscritosType : ObjectGraphType<FeaturesInscrito>
    {
        public FeaturesInscritosType(ReadRepository readRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "featuresINSCRITO";
            Field(t => t.Type).Description("Feature type");
            Field<InscritoLotePropertyType, InscritoLote>().Name("loteINSCRITOProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoLote>("loteINSCRITOPropertiesPorId", readRepository.GetPropsLotesInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoLoteGeometryType, InscritoLote>().Name("loteINSCRITOGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoLote>("loteINSCRITOGeometryPorId", readRepository.GetGeomLotesInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoCalleGeometryType, InscritoCalle>().Name("calleINSCRITOGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoCalle>("calleINSCRITOGeometryPorId", readRepository.GetGeomCallesInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoCallePropertyType, InscritoCalle>().Name("calleINSCRITOProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoCalle>("calleINSCRITOPropertiesPorId", readRepository.GetPropsCallesInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoManzanaGeometryType, InscritoManzana>().Name("manzanaINSCRITOGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoManzana>("manzanaINSCRITOGeometryPorId", readRepository.GetGeomManzanasInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoManzanaPropertyType, InscritoManzana>().Name("manzanaINSCRITOProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoManzana>("manzanaINSCRITOPropertiesPorId", readRepository.GetPropsManzanasInscritoByIdList);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<InscritoPuebloGeometryType, InscritoPueblo>().Name("puebloINSCRITOGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoPueblo>("puebloINSCRITOGeometryPorId", readRepository.GetGeomPueblosInscritoByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<InscritoPuebloPropertyType, InscritoPueblo>().Name("puebloINSCRITOProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, InscritoPueblo>("puebloINSCRITOPropertiesPorId", readRepository.GetPropsPueblosInscritoByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

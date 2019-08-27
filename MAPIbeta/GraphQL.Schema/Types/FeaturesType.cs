using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FeaturesType : ObjectGraphType<Features>
    {
        public FeaturesType(ReadRepository readRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "Features";
            Field(t => t.Type).Description("Feature type");
            Field<LoteGeometryType, Lote>().Name("loteGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Lote>("loteGeometryPorId", readRepository.GetGeomLotesByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<LotePropertyType, Lote>().Name("loteProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Lote>("lotePropertiesPorId", readRepository.GetPropsLotesByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<CalleGeometryType, Calle>().Name("calleGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Calle>("calleGeometryPorId", readRepository.GetGeomCallesByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<CallePropertyType, Calle>().Name("calleProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Calle>("callePropertiesPorId", readRepository.GetPropsCallesByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<ManzanaGeometryType, Manzana>().Name("manzanaGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Manzana>("manzanaGeometryPorId", readRepository.GetGeomManzanasByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<ManzanaPropertyType, Manzana>().Name("manzanaProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Manzana>("manzanaPropertiesPorId", readRepository.GetPropsManzanasByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<PuebloGeometryType, Pueblo>().Name("puebloGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Pueblo>("puebloGeometryPorId", readRepository.GetGeomPueblosByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<PuebloPropertyType, Pueblo>().Name("puebloProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Pueblo>("puebloPropertiesPorId", readRepository.GetPropsPueblosByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<UnidadTGeometryType, UnidadT>().Name("unidadtGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, UnidadT>("unidadtGeometryPorId", readRepository.GetGeomUnidadtByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<UnidadTPropertyType, UnidadT>().Name("unidadtProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, UnidadT>("unidadtPropertiesPorId", readRepository.GetPropsUnidadtByIdList);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

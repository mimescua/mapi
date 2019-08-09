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
            Field<LotePropertyType, Lote>().Name("loteProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Lote>("lotePropertiesPorId", readRepository.GetSomeLotesByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<LoteGeometryType, Lote>().Name("loteGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Lote>("loteGeometryPorId", readRepository.GetSomeLotesByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<CalleGeometryType, Calle>().Name("calleGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Calle>("calleGeometryPorId", readRepository.GetSomeCallesByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<CallePropertyType, Calle>().Name("calleProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Calle>("callePropertiesPorId", readRepository.GetSomeCallesByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<ManzanaGeometryType, Manzana>().Name("manzanaGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Manzana>("manzanaGeometryPorId", readRepository.GetSomeManzanasByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<ManzanaPropertyType, Manzana>().Name("manzanaProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Manzana>("manzanaPropertiesPorId", readRepository.GetSomeManzanasByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<PuebloGeometryType, Pueblo>().Name("puebloGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Pueblo>("puebloGeometryPorId", readRepository.GetSomePueblosByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<PuebloPropertyType, Pueblo>().Name("puebloProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, Pueblo>("puebloPropertiesPorId", readRepository.GetSomePueblosByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<UnidadTGeometryType, UnidadT>().Name("unidadtGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, UnidadT>("unidadtGeometryPorId", readRepository.GetSomeUnidaTsByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<UnidadTPropertyType, UnidadT>().Name("unidadtProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<int, UnidadT>("unidadtPropertiesPorId", readRepository.GetSomeUnidaTsByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

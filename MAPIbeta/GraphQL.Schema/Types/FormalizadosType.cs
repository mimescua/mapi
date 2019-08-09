using Data.Entities;
using Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class FormalizadosType : ObjectGraphType<Formalizados>
    {
        public FormalizadosType(ReadRepository readRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "bFeatures";
            Field(t => t.Type).Description("Feature type");
            Field<baseLotePropertyType, baseLote>().Name("bLoteProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseLote>("bLotePropertiesPorId", readRepository.GetSomeGeom_bLotesByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<baseLoteGeometryType, baseLote>().Name("bLoteGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseLote>("bLoteGeometryPorId", readRepository.GetSomeProps_bLotesByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<baseCalleGeometryType, baseCalle>().Name("bCalleGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseCalle>("bCalleGeometryPorId", readRepository.GetSomeGeom_bCallesByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<baseCallePropertyType, baseCalle>().Name("bCalleProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseCalle>("bCallePropertiesPorId", readRepository.GetSomeProps_bCallesByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<baseManzanaGeometryType, baseManzana>().Name("bManzanaGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseManzana>("bManzanaGeometryPorId", readRepository.GetSomeGeom_bManzanasByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });
            Field<baseManzanaPropertyType, baseManzana>().Name("bManzanaProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, baseManzana>("bManzanaPropertiesPorId", readRepository.GetSomeProps_bManzanasByIdAsync);
                return loader.LoadAsync(context.Source.Id.ToString());
            });

            //revisar si lo de abajo optimiza :)
            Field<basePuebloGeometryType, basePueblo>().Name("bPuebloGeometry").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, basePueblo>("bPuebloGeometryPorId", readRepository.GetSomeGeom_bPueblosByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
            Field<basePuebloPropertyType, basePueblo>().Name("bPuebloProperties").ResolveAsync(context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<string, basePueblo>("bPuebloPropertiesPorId", readRepository.GetSomeProps_bPueblosByIdAsync);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

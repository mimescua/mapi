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
            Field<LotePropertyType>(
                "loteProperties",
                resolve: context => readRepository.GetAllLoteProps(context.Source.Id)
            );
            Field<LoteGeometryType>(
                "loteGeometry",
                resolve: context => readRepository.GetAllLoteGeom(context.Source.Id)
            );
            Field<CalleGeometryType>(
                "calleGeometry",
                resolve: context => readRepository.GetAllCalleGeom(context.Source.Id)
            );
            Field<CallePropertyType>(
                "calleProperties",
                resolve: context => readRepository.GetAllCalleProps(context.Source.Id)
            );
            Field<ManzanaGeometryType>(
                "manzanaGeometry",
                resolve: context => readRepository.GetAllManzanaGeom(context.Source.Id)
            );
            Field<ManzanaPropertyType>(
                "manzanaProperties",
                resolve: context => readRepository.GetAllManzanaProps(context.Source.Id)
            );
            Field<ParcelaGeometryType>(
                "parcelaGeometry",
                resolve: context => readRepository.GetAllParcelaGeom(context.Source.Id)
            );
            Field<ParcelaPropertyType>(
                "parcelaProperties",
                resolve: context => readRepository.GetAllParcelaProps(context.Source.Id)
            );
            Field<PuebloGeometryType>(
                "puebloGeometry",
                resolve: context => readRepository.GetAllPuebloGeom(context.Source.Id)
            );
            Field<PuebloPropertyType>(
                "puebloProperties",
                resolve: context => readRepository.GetAllPuebloProps(context.Source.Id)
            );
            Field<UnidadTGeometryType>(
                "unidadtGeometry",
                resolve: context => readRepository.GetAllUnidadTGeom(context.Source.Id)
            );
            Field<UnidadTPropertyType>(
                "unidadtProperties",
                resolve: context => readRepository.GetAllUnidadTProps(context.Source.Id)
            );
        }
    }
}

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
        public FeaturesType(GeoRepository geoRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "Features";
            Field(t => t.Type).Description("Feature type");
            Field<LotePropertyType>(
                "loteProperties",
                resolve: context => geoRepository.GetLotePropsForFeature(context.Source.Id)
            );
            Field<LoteGeometryType>(//ENMASCARAR NOMBRE A "geometry"
                "loteGeometry",
                resolve: context => geoRepository.GetLoteGeomForFeature(context.Source.Id)
            );
            Field<CalleGeometryType>(
                "calleGeometry",
                resolve: context => geoRepository.GetCalleGeomForFeature(context.Source.Id)
            );
            Field<CallePropertyType>(
                "calleProperties",
                resolve: context => geoRepository.GetCallePropsForFeature(context.Source.Id)
            );
            Field<ManzanaGeometryType>(
                "manzanaGeometry",
                resolve: context => geoRepository.GetManzanaGeomForFeature(context.Source.Id)
            );
            Field<ManzanaPropertyType>(
                "manzanaProperties",
                resolve: context => geoRepository.GetManzanaPropsForFeature(context.Source.Id)
            );
            Field<ParcelaGeometryType>(
                "parcelaGeometry",
                resolve: context => geoRepository.GetParcelaGeomForFeature(context.Source.Id)
            );
            Field<ParcelaPropertyType>(
                "parcelaProperties",
                resolve: context => geoRepository.GetParcelaPropsForFeature(context.Source.Id)
            );
            Field<PuebloGeometryType>(
                "puebloGeometry",
                resolve: context => geoRepository.GetPuebloGeomForFeature(context.Source.Id)
            );
            Field<PuebloPropertyType>(
                "puebloProperties",
                resolve: context => geoRepository.GetPuebloPropsForFeature(context.Source.Id)
            );
            Field<UnidadTGeometryType>(
                "unidadtGeometry",
                resolve: context => geoRepository.GetUnidadTGeomForFeature(context.Source.Id)
            );
            Field<UnidadTPropertyType>(
                "unidadtProperties",
                resolve: context => geoRepository.GetUnidadTPropsForFeature(context.Source.Id)
            );
        }
    }
}

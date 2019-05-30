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
                resolve: context => geoRepository.GetAllLoteProps(context.Source.Id)
            );
            Field<LotePropertyType>(
                "sLoteProperties",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ubigeo" }),
                resolve: context =>
                {
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return geoRepository.GetLotePropsByUbigeo(context.Source.Id, ubigeo);
                }
            );
            Field<LoteGeometryType>(//ENMASCARAR NOMBRE A "geometry"
                "loteGeometry",
                resolve: context => geoRepository.GetAllLoteGeom(context.Source.Id)
            );
            Field<LoteGeometryType>(
                "sLoteGeometry",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ubigeo" }),
                resolve: context =>
                {
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return geoRepository.GetLoteGeomByUbigeo(context.Source.Id, ubigeo);
                }
            );
            Field<CalleGeometryType>(
                "calleGeometry",
                resolve: context => geoRepository.GetAllCalleGeom(context.Source.Id)
            );
            Field<CallePropertyType>(
                "calleProperties",
                resolve: context => geoRepository.GetAllCalleProps(context.Source.Id)
            );
            Field<ManzanaGeometryType>(
                "manzanaGeometry",
                resolve: context => geoRepository.GetAllManzanaGeom(context.Source.Id)
            );
            Field<ManzanaPropertyType>(
                "manzanaProperties",
                resolve: context => geoRepository.GetAllManzanaProps(context.Source.Id)
            );
            Field<ParcelaGeometryType>(
                "parcelaGeometry",
                resolve: context => geoRepository.GetAllParcelaGeom(context.Source.Id)
            );
            Field<ParcelaPropertyType>(
                "parcelaProperties",
                resolve: context => geoRepository.GetAllParcelaProps(context.Source.Id)
            );
            Field<PuebloGeometryType>(
                "puebloGeometry",
                resolve: context => geoRepository.GetAllPuebloGeom(context.Source.Id)
            );
            Field<PuebloPropertyType>(
                "puebloProperties",
                resolve: context => geoRepository.GetAllPuebloProps(context.Source.Id)
            );
            Field<UnidadTGeometryType>(
                "unidadtGeometry",
                resolve: context => geoRepository.GetAllUnidadTGeom(context.Source.Id)
            );
            Field<UnidadTPropertyType>(
                "unidadtProperties",
                resolve: context => geoRepository.GetAllUnidadTProps(context.Source.Id)
            );
        }
    }
}

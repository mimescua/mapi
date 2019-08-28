using Data.Repositories;
using GraphQL.Schema.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema
{
    public class mapiQuery : ObjectGraphType
    {
        public mapiQuery(ReadRepository readRepository)
        {
            Field<StringGraphType>(
                "type",
                resolve: context => "FeatureCollection"
                );
            Field<ListGraphType<FeaturesType>>(
                "features",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" },
                    new QueryArgument<ListGraphType<FloatGraphType>> { Name = "extent" },
                    new QueryArgument<StringGraphType> { Name = "plano" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var extent = context.GetArgument<List<double>>("extent");
                    var plano = context.GetArgument<string>("plano");
                    return readRepository.GetFormalizacion(tipo, extent, plano);
                }
            );
            Field<ListGraphType<FeaturesInscritosType>>(
                "featuresPSAD56",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" },
                    new QueryArgument<ListGraphType<FloatGraphType>> { Name = "extent" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var extent = context.GetArgument<double[]>("extent");
                    return readRepository.GetInscritosPSAD56(tipo, extent);
                }
            );
            Field<ListGraphType<FeaturesInscritosType>>(
                "featuresWGS84",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" },
                    new QueryArgument<ListGraphType<FloatGraphType>> { Name = "extent" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var extent = context.GetArgument<double[]>("extent");
                    return readRepository.GetInscritosWGS84(tipo, extent);
                }
            );
            Field<ListGraphType<FeaturesMatrizType>>(
                "featuresMatriz",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" },
                    new QueryArgument<ListGraphType<FloatGraphType>> { Name = "extent" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var extent = context.GetArgument<double[]>("extent");
                    return readRepository.GetMatrices(tipo, extent);
                }
            );
            Field<ListGraphType<FeaturesTematicoType>>(
                "featuresTematico",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tipo" },
                    new QueryArgument<StringGraphType> { Name = "anio" },
                    new QueryArgument<ListGraphType<FloatGraphType>> { Name = "extent" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var anio = context.GetArgument<string>("anio");
                    var extent = context.GetArgument<double[]>("extent");
                    return readRepository.GetTematico(tipo, anio, extent);
                }
            );

            Field<ListGraphType<PuebloInformeType>>(
                "puebloInformeCodPueblo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "codpueblo" }
                ),
                resolve: context =>
                {
                    var codpueblo = context.GetArgument<string>("codpueblo");
                    return readRepository.GetPuebloInformeByCodPueblo(codpueblo);
                }
            );
            Field<ListGraphType<PuebloInformeType>>(
                "puebloInformeNombre",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" }
                ),
                resolve: context =>
                {
                    var nombre = context.GetArgument<string>("nombre");
                    return readRepository.GetPuebloInformeByNombre(nombre);
                }
            );
            Field<ListGraphType<PuebloInformeType>>(
                "puebloInformeCodCofopri",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "codcofopri" }
                ),
                resolve: context =>
                {
                    var codcofopri = context.GetArgument<string>("codcofopri");
                    return readRepository.GetPuebloInformeByCodCofopri(codcofopri);
                }
            );

            Field<ListGraphType<CentroideType>>(
                "distrito",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" }
                ),
                resolve: context =>
                {
                    var nombre = context.GetArgument<string>("nombre");
                    return readRepository.GetDistritoCentroideComo(nombre);
                }
            );
            Field<ListGraphType<CentroideType>>(
                "provincia",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" }
                ),
                resolve: context =>
                {
                    var nombre = context.GetArgument<string>("nombre");
                    return readRepository.GetProvinciaCentroideComo(nombre);
                }
            );
            Field<ListGraphType<CentroideType>>(
                "region",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" }
                ),
                resolve: context =>
                {
                    var nombre = context.GetArgument<string>("nombre");
                    return readRepository.GetRegionCentroideComo(nombre);
                }
            );
            Field<baseDistritoGeometryType>(
                "basedistrito",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ubigeo" }
                ),
                resolve: context =>
                {
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return readRepository.GetBaseDistritoPor(ubigeo);
                }
            );
            Field<baseProvinciaGeometryType>(
                "baseprovincia",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ubigeo" }
                ),
                resolve: context =>
                {
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return readRepository.GetBaseProvinciaPor(ubigeo);
                }
            );
            Field<baseRegionGeometryType>(
                "baseregion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ubigeo" }
                ),
                resolve: context =>
                {
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return readRepository.GetBaseRegionPor(ubigeo);
                }
            );
        }
    }
}
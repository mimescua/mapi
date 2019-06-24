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
                    new QueryArgument<StringGraphType> { Name = "nombre" },
                    new QueryArgument<StringGraphType> { Name = "ubigeo" }
                ),
                resolve: context =>
                {
                    var tipo = context.GetArgument<string>("tipo");
                    var nombre = context.GetArgument<string>("nombre");
                    var ubigeo = context.GetArgument<string>("ubigeo");
                    return readRepository.GetFeaturesBy(tipo,nombre,ubigeo);
                }
            );
            Field<ListGraphType<FormalizacionType>>(
                "puebloexistente",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "codpueblo" }
                ),
                resolve: context =>
                {
                    var codpueblo = context.GetArgument<string>("codpueblo");
                    return readRepository.GetPuebloExistenteByUbigeo(codpueblo);
                }
            );
            Field<ListGraphType<CentroideType>>(
                "centroide",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "centroide" }
                ),
                resolve: context =>
                {
                    var centroide = context.GetArgument<string>("centroide");
                    return readRepository.GetCentroidesByUbigeo(centroide);
                }
            );
        }
    }
}
using Data.Entities;
using Data.Repositories;
using GraphQL.Schema.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema
{
    public class mapiMutation : ObjectGraphType
    {
        public mapiMutation(AddRepository addRepository)
        {
            FieldAsync<UnidadTType>(
                "crearUnidadTerritorial",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UnidadTInputType>> { Name = "feature"}),
                resolve: async context =>
                {
                    var unidadT = context.GetArgument<UnidadT>("feature");
                    return await context.TryAsyncResolve(
                        async c => await addRepository.AddUnidadT(unidadT));
                }
            );
        }
    }
}
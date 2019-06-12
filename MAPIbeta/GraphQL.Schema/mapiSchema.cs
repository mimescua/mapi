using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema
{
    public class mapiSchema: GraphQL.Types.Schema
    {
        public mapiSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<mapiQuery>();
            Mutation = resolver.Resolve<mapiMutation>();
        }
    }
}
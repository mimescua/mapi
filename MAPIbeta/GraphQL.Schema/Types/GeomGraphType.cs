using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Schema.Types
{
    public class GeomGraphType : ScalarGraphType
    {
        public GeomGraphType()
        {
            Name = "Custom";
            Description = "A custom scalar type (example).";
        }

        public override object Serialize(object value)
        {
            return $"CUSTOM:{value?.ToString()}";
        }

        public override object ParseValue(object value)
        {
            return new Custom
            {
                Value = value?.ToString().Replace("\"", "").Replace("CUSTOM:", ""),
            };
        }

        public override object ParseLiteral(IValue value)
        {
            var str = value as StringValue;
            if (str != null)
            {
                return ParseValue(str.Value);
            }
            return null;
        }
    }

    public class Custom
    {
        public string Value { get; set; }

        public override string ToString() => Value;
    }
}

using System;
using System.Linq.Expressions;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration
{
    internal class DefaultTypeAdapterConfiguration<T, TResult> : TypeAdapterConfig
    {
        public DefaultTypeAdapterConfiguration()
        {
            ForType<ExpressionNode, Expression<Func<T, TResult>>>();

            ForType<Expression<Func<T, TResult>>, ExpressionNode>();
        }
    }
}
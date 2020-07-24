using System;
using System.Linq.Expressions;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal static class ExpressionNodeMapper
    {
        internal static Expression<Func<T, TResult>> Map<T, TResult>(Expressions.Abstract.ExpressionNode source, TypeAdapterConfig configuration)
        {
            return null;
        }
    }
}
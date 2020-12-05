using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ExpressionMapper<T, TResult> : ExpressionMapperBase<Expression<Func<T, TResult>>, Expressions.Abstract.ExpressionNode>
    {
        public ExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override Expressions.Abstract.ExpressionNode Map(Expression<Func<T, TResult>> source)
        {
            return new LambdaExpressionMapper(Configuration).Map(source);
        }
    }
}
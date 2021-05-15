using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ExpressionMapper<T> : ExpressionMapperBase<Expression<T>, Expressions.Abstract.ExpressionNode>
    {
        public ExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expressions.Abstract.ExpressionNode Map(Expression<T> source)
        {
            if (source is LambdaExpression lambdaExpression)
                return new LambdaExpressionMapper(Configuration).Map(lambdaExpression);

            throw new NotSupportedException();
        }
    }
}
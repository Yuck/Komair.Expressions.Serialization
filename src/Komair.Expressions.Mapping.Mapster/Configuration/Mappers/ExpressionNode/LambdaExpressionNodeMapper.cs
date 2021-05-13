using System;
using System.Linq.Expressions;
using Komair.Expressions.Extensions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class LambdaExpressionNodeMapper<T, TResult> : ExpressionNodeMapperBase<LambdaExpressionNode, Expression<Func<T, TResult>>>
    {
        public LambdaExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expression<Func<T, TResult>> Map(LambdaExpressionNode source)
        {
            var body = source.Body.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var parameters = body.GetParameterList();
            var result = System.Linq.Expressions.Expression.Lambda<Func<T, TResult>>(body, parameters);

            return result;
        }
    }
}
using System.Linq.Expressions;
using Komair.Expressions.Extensions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class LambdaExpressionNodeMapper<T> : ExpressionNodeMapperBase<LambdaExpressionNode, Expression<T>>
    {
        public LambdaExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expression<T> Map(LambdaExpressionNode source)
        {
            var body = source.Body.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var parameters = body.GetParameterList();
            var result = System.Linq.Expressions.Expression.Lambda<T>(body, parameters);

            return result;
        }
    }
}
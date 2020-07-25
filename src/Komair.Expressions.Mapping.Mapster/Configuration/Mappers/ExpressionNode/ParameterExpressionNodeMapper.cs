using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ParameterExpressionNodeMapper : ExpressionNodeMapperBase<ParameterExpressionNode, ParameterExpression>
    {
        public ParameterExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override ParameterExpression Map(ParameterExpressionNode source)
        {
            var result = System.Linq.Expressions.Expression.Parameter(source.Type, source.Name);

            return result;
        }
    }
}
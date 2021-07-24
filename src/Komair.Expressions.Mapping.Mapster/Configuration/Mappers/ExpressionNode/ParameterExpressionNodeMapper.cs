using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ParameterExpressionNodeMapper : ExpressionNodeMapperBase<ParameterExpressionNode, ParameterExpression>
    {
        public ParameterExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override ParameterExpression Map(ParameterExpressionNode source)
        {
            var type = source.Type;
            var name = source.Name;
            var result = LinqExpression.Parameter(type, name);

            return result;
        }
    }
}
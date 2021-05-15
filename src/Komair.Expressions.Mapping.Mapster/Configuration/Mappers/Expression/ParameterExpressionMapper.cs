using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ParameterExpressionMapper : ExpressionMapperBase<ParameterExpression, ParameterExpressionNode>
    {
        public ParameterExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override ParameterExpressionNode Map(ParameterExpression source)
        {
            var nodeType = source.NodeType;
            var type = source.Type;
            var result = new ParameterExpressionNode(nodeType, type)
            {
                Name = source.Name
            };

            return result;
        }
    }
}
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ParameterExpressionMapper : ExpressionMapperBase<ParameterExpression, ParameterExpressionNode>
    {
        public ParameterExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override ParameterExpressionNode Map(ParameterExpression source)
        {
            var result = new ParameterExpressionNode(source.NodeType, source.Type)
            {
                Name = source.Name
            };

            return result;
        }
    }
}
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ConstantExpressionMapper : ExpressionMapperBase<ConstantExpression, ConstantExpressionNode>
    {
        public ConstantExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override ConstantExpressionNode Map(ConstantExpression source)
        {
            var result = new ConstantExpressionNode(source.NodeType, source.Type)
            {
                Value = source.Value
            };

            return result;
        }
    }
}
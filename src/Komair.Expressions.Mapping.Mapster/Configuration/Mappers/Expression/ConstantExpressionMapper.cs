using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ConstantExpressionMapper : ExpressionMapperBase<ConstantExpression, ConstantExpressionNode>
    {
        public ConstantExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override ConstantExpressionNode Map(ConstantExpression source)
        {
            var nodeType = source.NodeType;
            var type = source.Type;
            var result = new ConstantExpressionNode(nodeType, type)
            {
                Value = source.Value
            };

            return result;
        }
    }
}
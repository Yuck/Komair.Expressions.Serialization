using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ConstantExpressionNodeMapper : ExpressionNodeMapperBase<ConstantExpressionNode, ConstantExpression>
    {
        public ConstantExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override ConstantExpression Map(ConstantExpressionNode source)
        {
            var type = source.NodeType;
            var value = source.Value.GetType() != type
                            ? Convert.ChangeType(source.Value, type)
                            : source.Value;
            var result = System.Linq.Expressions.Expression.Constant(value, type);

            return result;
        }
    }
}
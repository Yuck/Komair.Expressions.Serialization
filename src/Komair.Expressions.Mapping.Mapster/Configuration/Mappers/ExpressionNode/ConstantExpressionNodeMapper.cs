using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ConstantExpressionNodeMapper : ExpressionNodeMapperBase<ConstantExpressionNode, ConstantExpression>
    {
        public ConstantExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override ConstantExpression Map(ConstantExpressionNode source)
        {
            var value = source.Value.GetType() != source.Type
                            ? Convert.ChangeType(source.Value, source.Type)
                            : source.Value;
            var result = System.Linq.Expressions.Expression.Constant(value, source.Type);

            return result;
        }
    }
}
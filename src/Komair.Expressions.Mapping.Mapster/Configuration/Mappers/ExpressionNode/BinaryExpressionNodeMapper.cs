using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class BinaryExpressionNodeMapper : ExpressionNodeMapperBase<BinaryExpressionNode, BinaryExpression>
    {
        public BinaryExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override BinaryExpression Map(BinaryExpressionNode source)
        {
            var left = source.Left.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var right = source.Right.Adapt<System.Linq.Expressions.Expression>(Configuration);

            switch (source.NodeType)
            {
                case ExpressionType.GreaterThan:
                    return System.Linq.Expressions.Expression.GreaterThan(left, right);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
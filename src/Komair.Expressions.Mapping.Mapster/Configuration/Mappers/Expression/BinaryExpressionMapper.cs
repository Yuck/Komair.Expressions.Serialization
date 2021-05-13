using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class BinaryExpressionMapper : ExpressionMapperBase<BinaryExpression, BinaryExpressionNode>
    {
        public BinaryExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override BinaryExpressionNode Map(BinaryExpression source)
        {
            var result = new BinaryExpressionNode(source.NodeType, source.Type)
            {
                Left = source.Left.Adapt<Expressions.Abstract.ExpressionNode>(Configuration),
                Right = source.Right.Adapt<Expressions.Abstract.ExpressionNode>(Configuration)
            };

            return result;
        }
    }
}
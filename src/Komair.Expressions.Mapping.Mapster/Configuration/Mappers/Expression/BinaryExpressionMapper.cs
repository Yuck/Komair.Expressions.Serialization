using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression;

internal class BinaryExpressionMapper : ExpressionMapperBase<BinaryExpression, BinaryExpressionNode>
{
    public BinaryExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

    public override BinaryExpressionNode Map(BinaryExpression source)
    {
        var nodeType = source.NodeType;
        var type = source.Type;
        var left = source.Left.Adapt<ExpressionNodeBase>(Configuration);
        var right = source.Right.Adapt<ExpressionNodeBase>(Configuration);
        var result = new BinaryExpressionNode(nodeType, type)
        {
            Left = left,
            Right = right
        };

        return result;
    }
}

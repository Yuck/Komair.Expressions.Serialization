using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode;

internal class BinaryExpressionNodeMapper : ExpressionNodeMapperBase<BinaryExpressionNode, BinaryExpression>
{
    public BinaryExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

    public override BinaryExpression Map(BinaryExpressionNode source)
    {
        var left = source.Left.Adapt<LinqExpression>(Configuration);
        var right = source.Right.Adapt<LinqExpression>(Configuration);

        return source.NodeType switch
        {
            ExpressionType.Add => LinqExpression.Add(left, right),
            ExpressionType.AddAssign => LinqExpression.AddAssign(left, right),
            ExpressionType.AddAssignChecked => LinqExpression.AddAssignChecked(left, right),
            ExpressionType.AddChecked => LinqExpression.AddChecked(left, right),
            ExpressionType.And => LinqExpression.And(left, right),
            ExpressionType.AndAlso => LinqExpression.AndAlso(left, right),
            ExpressionType.AndAssign => LinqExpression.AndAssign(left, right),
            ExpressionType.Assign => LinqExpression.Assign(left, right),
            ExpressionType.Coalesce => LinqExpression.Coalesce(left, right),
            ExpressionType.Divide => LinqExpression.Divide(left, right),
            ExpressionType.DivideAssign => LinqExpression.DivideAssign(left, right),
            ExpressionType.Equal => LinqExpression.Equal(left, right),
            ExpressionType.ExclusiveOr => LinqExpression.ExclusiveOr(left, right),
            ExpressionType.ExclusiveOrAssign => LinqExpression.ExclusiveOrAssign(left, right),
            ExpressionType.GreaterThan => LinqExpression.GreaterThan(left, right),
            ExpressionType.GreaterThanOrEqual => LinqExpression.GreaterThanOrEqual(left, right),
            ExpressionType.LeftShift => LinqExpression.LeftShift(left, right),
            ExpressionType.LeftShiftAssign => LinqExpression.LeftShiftAssign(left, right),
            ExpressionType.LessThan => LinqExpression.LessThan(left, right),
            ExpressionType.LessThanOrEqual => LinqExpression.LessThanOrEqual(left, right),
            ExpressionType.Modulo => LinqExpression.Modulo(left, right),
            ExpressionType.ModuloAssign => LinqExpression.ModuloAssign(left, right),
            ExpressionType.Multiply => LinqExpression.Multiply(left, right),
            ExpressionType.MultiplyAssign => LinqExpression.MultiplyAssign(left, right),
            ExpressionType.MultiplyAssignChecked => LinqExpression.MultiplyAssignChecked(left, right),
            ExpressionType.MultiplyChecked => LinqExpression.MultiplyChecked(left, right),
            ExpressionType.NotEqual => LinqExpression.NotEqual(left, right),
            ExpressionType.Or => LinqExpression.Or(left, right),
            ExpressionType.OrAssign => LinqExpression.OrAssign(left, right),
            ExpressionType.OrElse => LinqExpression.OrElse(left, right),
            ExpressionType.Power => LinqExpression.Power(left, right),
            ExpressionType.PowerAssign => LinqExpression.PowerAssign(left, right),
            ExpressionType.RightShift => LinqExpression.RightShift(left, right),
            ExpressionType.RightShiftAssign => LinqExpression.RightShiftAssign(left, right),
            ExpressionType.Subtract => LinqExpression.Subtract(left, right),
            ExpressionType.SubtractAssign => LinqExpression.SubtractAssign(left, right),
            ExpressionType.SubtractAssignChecked => LinqExpression.SubtractAssignChecked(left, right),
            ExpressionType.SubtractChecked => LinqExpression.SubtractChecked(left, right),
            _ => throw new NotSupportedException()
        };
    }
}

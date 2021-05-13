using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class BinaryExpressionNodeMapper : ExpressionNodeMapperBase<BinaryExpressionNode, BinaryExpression>
    {
        public BinaryExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override BinaryExpression Map(BinaryExpressionNode source)
        {
            var left = source.Left.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var right = source.Right.Adapt<System.Linq.Expressions.Expression>(Configuration);

            switch (source.ExpressionType)
            {
                case ExpressionType.Add:
                    return System.Linq.Expressions.Expression.Add(left, right);
                case ExpressionType.AddAssign:
                    return System.Linq.Expressions.Expression.AddAssign(left, right);
                case ExpressionType.AddAssignChecked:
                    return System.Linq.Expressions.Expression.AddAssignChecked(left, right);
                case ExpressionType.AddChecked:
                    return System.Linq.Expressions.Expression.AddChecked(left, right);
                case ExpressionType.And:
                    return System.Linq.Expressions.Expression.And(left, right);
                case ExpressionType.AndAlso:
                    return System.Linq.Expressions.Expression.AndAlso(left, right);
                case ExpressionType.AndAssign:
                    return System.Linq.Expressions.Expression.AndAssign(left, right);
                case ExpressionType.Assign:
                    return System.Linq.Expressions.Expression.Assign(left, right);
                case ExpressionType.Coalesce:
                    return System.Linq.Expressions.Expression.Coalesce(left, right);
                case ExpressionType.Divide:
                    return System.Linq.Expressions.Expression.Divide(left, right);
                case ExpressionType.DivideAssign:
                    return System.Linq.Expressions.Expression.DivideAssign(left, right);
                case ExpressionType.Equal:
                    return System.Linq.Expressions.Expression.Equal(left, right);
                case ExpressionType.ExclusiveOr:
                    return System.Linq.Expressions.Expression.ExclusiveOr(left, right);
                case ExpressionType.ExclusiveOrAssign:
                    return System.Linq.Expressions.Expression.ExclusiveOrAssign(left, right);
                case ExpressionType.GreaterThan:
                    return System.Linq.Expressions.Expression.GreaterThan(left, right);
                case ExpressionType.GreaterThanOrEqual:
                    return System.Linq.Expressions.Expression.GreaterThanOrEqual(left, right);
                case ExpressionType.LeftShift:
                    return System.Linq.Expressions.Expression.LeftShift(left, right);
                case ExpressionType.LeftShiftAssign:
                    return System.Linq.Expressions.Expression.LeftShiftAssign(left, right);
                case ExpressionType.LessThan:
                    return System.Linq.Expressions.Expression.LessThan(left, right);
                case ExpressionType.LessThanOrEqual:
                    return System.Linq.Expressions.Expression.LessThanOrEqual(left, right);
                case ExpressionType.Modulo:
                    return System.Linq.Expressions.Expression.Modulo(left, right);
                case ExpressionType.ModuloAssign:
                    return System.Linq.Expressions.Expression.ModuloAssign(left, right);
                case ExpressionType.Multiply:
                    return System.Linq.Expressions.Expression.Multiply(left, right);
                case ExpressionType.MultiplyAssign:
                    return System.Linq.Expressions.Expression.MultiplyAssign(left, right);
                case ExpressionType.MultiplyAssignChecked:
                    return System.Linq.Expressions.Expression.MultiplyAssignChecked(left, right);
                case ExpressionType.MultiplyChecked:
                    return System.Linq.Expressions.Expression.MultiplyChecked(left, right);
                case ExpressionType.NotEqual:
                    return System.Linq.Expressions.Expression.NotEqual(left, right);
                case ExpressionType.Or:
                    return System.Linq.Expressions.Expression.Or(left, right);
                case ExpressionType.OrAssign:
                    return System.Linq.Expressions.Expression.OrAssign(left, right);
                case ExpressionType.OrElse:
                    return System.Linq.Expressions.Expression.OrElse(left, right);
                case ExpressionType.Power:
                    return System.Linq.Expressions.Expression.Power(left, right);
                case ExpressionType.PowerAssign:
                    return System.Linq.Expressions.Expression.PowerAssign(left, right);
                case ExpressionType.RightShift:
                    return System.Linq.Expressions.Expression.RightShift(left, right);
                case ExpressionType.RightShiftAssign:
                    return System.Linq.Expressions.Expression.RightShiftAssign(left, right);
                case ExpressionType.Subtract:
                    return System.Linq.Expressions.Expression.Subtract(left, right);
                case ExpressionType.SubtractAssign:
                    return System.Linq.Expressions.Expression.SubtractAssign(left, right);
                case ExpressionType.SubtractAssignChecked:
                    return System.Linq.Expressions.Expression.SubtractAssignChecked(left, right);
                case ExpressionType.SubtractChecked:
                    return System.Linq.Expressions.Expression.SubtractChecked(left, right);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
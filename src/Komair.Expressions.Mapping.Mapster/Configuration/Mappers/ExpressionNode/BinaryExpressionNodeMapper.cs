using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class BinaryExpressionNodeMapper : ExpressionNodeMapperBase<BinaryExpressionNode, BinaryExpression>
    {
        public BinaryExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override BinaryExpression Map(BinaryExpressionNode source)
        {
            var left = source.Left.Adapt<LinqExpression>(Configuration);
            var right = source.Right.Adapt<LinqExpression>(Configuration);

            switch (source.NodeType)
            {
                case ExpressionType.Add:
                    return LinqExpression.Add(left, right);
                case ExpressionType.AddAssign:
                    return LinqExpression.AddAssign(left, right);
                case ExpressionType.AddAssignChecked:
                    return LinqExpression.AddAssignChecked(left, right);
                case ExpressionType.AddChecked:
                    return LinqExpression.AddChecked(left, right);
                case ExpressionType.And:
                    return LinqExpression.And(left, right);
                case ExpressionType.AndAlso:
                    return LinqExpression.AndAlso(left, right);
                case ExpressionType.AndAssign:
                    return LinqExpression.AndAssign(left, right);
                case ExpressionType.Assign:
                    return LinqExpression.Assign(left, right);
                case ExpressionType.Coalesce:
                    return LinqExpression.Coalesce(left, right);
                case ExpressionType.Divide:
                    return LinqExpression.Divide(left, right);
                case ExpressionType.DivideAssign:
                    return LinqExpression.DivideAssign(left, right);
                case ExpressionType.Equal:
                    return LinqExpression.Equal(left, right);
                case ExpressionType.ExclusiveOr:
                    return LinqExpression.ExclusiveOr(left, right);
                case ExpressionType.ExclusiveOrAssign:
                    return LinqExpression.ExclusiveOrAssign(left, right);
                case ExpressionType.GreaterThan:
                    return LinqExpression.GreaterThan(left, right);
                case ExpressionType.GreaterThanOrEqual:
                    return LinqExpression.GreaterThanOrEqual(left, right);
                case ExpressionType.LeftShift:
                    return LinqExpression.LeftShift(left, right);
                case ExpressionType.LeftShiftAssign:
                    return LinqExpression.LeftShiftAssign(left, right);
                case ExpressionType.LessThan:
                    return LinqExpression.LessThan(left, right);
                case ExpressionType.LessThanOrEqual:
                    return LinqExpression.LessThanOrEqual(left, right);
                case ExpressionType.Modulo:
                    return LinqExpression.Modulo(left, right);
                case ExpressionType.ModuloAssign:
                    return LinqExpression.ModuloAssign(left, right);
                case ExpressionType.Multiply:
                    return LinqExpression.Multiply(left, right);
                case ExpressionType.MultiplyAssign:
                    return LinqExpression.MultiplyAssign(left, right);
                case ExpressionType.MultiplyAssignChecked:
                    return LinqExpression.MultiplyAssignChecked(left, right);
                case ExpressionType.MultiplyChecked:
                    return LinqExpression.MultiplyChecked(left, right);
                case ExpressionType.NotEqual:
                    return LinqExpression.NotEqual(left, right);
                case ExpressionType.Or:
                    return LinqExpression.Or(left, right);
                case ExpressionType.OrAssign:
                    return LinqExpression.OrAssign(left, right);
                case ExpressionType.OrElse:
                    return LinqExpression.OrElse(left, right);
                case ExpressionType.Power:
                    return LinqExpression.Power(left, right);
                case ExpressionType.PowerAssign:
                    return LinqExpression.PowerAssign(left, right);
                case ExpressionType.RightShift:
                    return LinqExpression.RightShift(left, right);
                case ExpressionType.RightShiftAssign:
                    return LinqExpression.RightShiftAssign(left, right);
                case ExpressionType.Subtract:
                    return LinqExpression.Subtract(left, right);
                case ExpressionType.SubtractAssign:
                    return LinqExpression.SubtractAssign(left, right);
                case ExpressionType.SubtractAssignChecked:
                    return LinqExpression.SubtractAssignChecked(left, right);
                case ExpressionType.SubtractChecked:
                    return LinqExpression.SubtractChecked(left, right);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
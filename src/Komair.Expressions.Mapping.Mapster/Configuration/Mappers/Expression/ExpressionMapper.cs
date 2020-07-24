using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ExpressionMapper<T, TResult> : ExpressionMapperBase<Expression<Func<T, TResult>>, Expressions.Abstract.ExpressionNode>
    {
        public ExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override Expressions.Abstract.ExpressionNode Map(Expression<Func<T, TResult>> source)
        {
            switch (source.NodeType)
            {
                case ExpressionType.Add:
                    throw new NotSupportedException();
                case ExpressionType.AddAssign:
                    throw new NotSupportedException();
                case ExpressionType.AddAssignChecked:
                    throw new NotSupportedException();
                case ExpressionType.AddChecked:
                    throw new NotSupportedException();
                case ExpressionType.And:
                    throw new NotSupportedException();
                case ExpressionType.AndAlso:
                    throw new NotSupportedException();
                case ExpressionType.AndAssign:
                    throw new NotSupportedException();
                case ExpressionType.ArrayIndex:
                    throw new NotSupportedException();
                case ExpressionType.ArrayLength:
                    throw new NotSupportedException();
                case ExpressionType.Assign:
                    throw new NotSupportedException();
                case ExpressionType.Block:
                    throw new NotSupportedException();
                case ExpressionType.Call:
                    throw new NotSupportedException();
                case ExpressionType.Coalesce:
                    throw new NotSupportedException();
                case ExpressionType.Conditional:
                    throw new NotSupportedException();
                case ExpressionType.Constant:
                    throw new NotSupportedException();
                case ExpressionType.Convert:
                    throw new NotSupportedException();
                case ExpressionType.ConvertChecked:
                    throw new NotSupportedException();
                case ExpressionType.DebugInfo:
                    throw new NotSupportedException();
                case ExpressionType.Decrement:
                    throw new NotSupportedException();
                case ExpressionType.Default:
                    throw new NotSupportedException();
                case ExpressionType.Divide:
                    throw new NotSupportedException();
                case ExpressionType.DivideAssign:
                    throw new NotSupportedException();
                case ExpressionType.Dynamic:
                    throw new NotSupportedException();
                case ExpressionType.Equal:
                    throw new NotSupportedException();
                case ExpressionType.ExclusiveOr:
                    throw new NotSupportedException();
                case ExpressionType.ExclusiveOrAssign:
                    throw new NotSupportedException();
                case ExpressionType.Extension:
                    throw new NotSupportedException();
                case ExpressionType.Goto:
                    throw new NotSupportedException();
                case ExpressionType.GreaterThan:
                    throw new NotSupportedException();
                case ExpressionType.GreaterThanOrEqual:
                    throw new NotSupportedException();
                case ExpressionType.Increment:
                    throw new NotSupportedException();
                case ExpressionType.Index:
                    throw new NotSupportedException();
                case ExpressionType.Invoke:
                    throw new NotSupportedException();
                case ExpressionType.IsFalse:
                    throw new NotSupportedException();
                case ExpressionType.IsTrue:
                    throw new NotSupportedException();
                case ExpressionType.Label:
                    throw new NotSupportedException();
                case ExpressionType.Lambda:
                    return new LambdaExpressionMapper(Configuration).Map(source);
                case ExpressionType.LeftShift:
                    throw new NotSupportedException();
                case ExpressionType.LeftShiftAssign:
                    throw new NotSupportedException();
                case ExpressionType.LessThan:
                    throw new NotSupportedException();
                case ExpressionType.LessThanOrEqual:
                    throw new NotSupportedException();
                case ExpressionType.ListInit:
                    throw new NotSupportedException();
                case ExpressionType.Loop:
                    throw new NotSupportedException();
                case ExpressionType.MemberAccess:
                    throw new NotSupportedException();
                case ExpressionType.MemberInit:
                    throw new NotSupportedException();
                case ExpressionType.Modulo:
                    throw new NotSupportedException();
                case ExpressionType.ModuloAssign:
                    throw new NotSupportedException();
                case ExpressionType.Multiply:
                    throw new NotSupportedException();
                case ExpressionType.MultiplyAssign:
                    throw new NotSupportedException();
                case ExpressionType.MultiplyAssignChecked:
                    throw new NotSupportedException();
                case ExpressionType.MultiplyChecked:
                    throw new NotSupportedException();
                case ExpressionType.Negate:
                    throw new NotSupportedException();
                case ExpressionType.NegateChecked:
                    throw new NotSupportedException();
                case ExpressionType.New:
                    throw new NotSupportedException();
                case ExpressionType.NewArrayBounds:
                    throw new NotSupportedException();
                case ExpressionType.NewArrayInit:
                    throw new NotSupportedException();
                case ExpressionType.Not:
                    throw new NotSupportedException();
                case ExpressionType.NotEqual:
                    throw new NotSupportedException();
                case ExpressionType.OnesComplement:
                    throw new NotSupportedException();
                case ExpressionType.Or:
                    throw new NotSupportedException();
                case ExpressionType.OrAssign:
                    throw new NotSupportedException();
                case ExpressionType.OrElse:
                    throw new NotSupportedException();
                case ExpressionType.Parameter:
                    throw new NotSupportedException();
                case ExpressionType.PostDecrementAssign:
                    throw new NotSupportedException();
                case ExpressionType.PostIncrementAssign:
                    throw new NotSupportedException();
                case ExpressionType.Power:
                    throw new NotSupportedException();
                case ExpressionType.PowerAssign:
                    throw new NotSupportedException();
                case ExpressionType.PreDecrementAssign:
                    throw new NotSupportedException();
                case ExpressionType.PreIncrementAssign:
                    throw new NotSupportedException();
                case ExpressionType.Quote:
                    throw new NotSupportedException();
                case ExpressionType.RightShift:
                    throw new NotSupportedException();
                case ExpressionType.RightShiftAssign:
                    throw new NotSupportedException();
                case ExpressionType.RuntimeVariables:
                    throw new NotSupportedException();
                case ExpressionType.Subtract:
                    throw new NotSupportedException();
                case ExpressionType.SubtractAssign:
                    throw new NotSupportedException();
                case ExpressionType.SubtractAssignChecked:
                    throw new NotSupportedException();
                case ExpressionType.SubtractChecked:
                    throw new NotSupportedException();
                case ExpressionType.Switch:
                    throw new NotSupportedException();
                case ExpressionType.Throw:
                    throw new NotSupportedException();
                case ExpressionType.Try:
                    throw new NotSupportedException();
                case ExpressionType.TypeAs:
                    throw new NotSupportedException();
                case ExpressionType.TypeEqual:
                    throw new NotSupportedException();
                case ExpressionType.TypeIs:
                    throw new NotSupportedException();
                case ExpressionType.UnaryPlus:
                    throw new NotSupportedException();
                case ExpressionType.Unbox:
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Serialization.Mapping.Abstract
{
    public interface IExpressionNodeMapper<T, TResult>
    {
        Expression<Func<T, TResult>> ToExpression(ExpressionNode expression);
        ExpressionNode ToExpressionNode(Expression<Func<T, TResult>> expression);
    }
}
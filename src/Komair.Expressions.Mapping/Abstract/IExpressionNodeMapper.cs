using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions.Mapping.Abstract
{
    public interface IExpressionNodeMapper<T, TResult>
    {
        Expression<Func<T, TResult>> ToExpression(ExpressionNode expression);
        ExpressionNode ToExpressionNode(Expression<Func<T, TResult>> expression);
    }
}
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions.Mapping.Abstract
{
    public interface IExpressionNodeMapper<T>
    {
        Expression<T> ToExpression(ExpressionNode node);
        ExpressionNode ToExpressionNode(Expression<T> expression);
    }
}
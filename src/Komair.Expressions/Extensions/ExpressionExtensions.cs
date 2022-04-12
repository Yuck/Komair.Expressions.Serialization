using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Komair.Expressions.Extensions;

public static class ExpressionExtensions
{
    public static IReadOnlyCollection<ParameterExpression> GetParameterList(this BinaryExpression expression)
    {
        if (expression == null)
            return new List<ParameterExpression>();

        var result = new List<ParameterExpression>();

        result.AddRange(expression.Left.GetParameterList());
        result.AddRange(expression.Right.GetParameterList());

        return result.GroupBy(t => t.Name).Select(t => t.First()).ToList();
    }

    public static IReadOnlyCollection<ParameterExpression> GetParameterList(this Expression expression)
    {
        if (expression == null)
            return new List<ParameterExpression>();

        return expression switch
        {
            BinaryExpression binary => binary.GetParameterList(),
            MemberExpression member => member.GetParameterList(),
            ParameterExpression parameter => new List<ParameterExpression> { parameter },
            _ => new List<ParameterExpression>()
        };
    }

    public static IReadOnlyCollection<ParameterExpression> GetParameterList(this MemberExpression expression)
    {
        var result = expression == null
                         ? new List<ParameterExpression>()
                         : expression.Expression.GetParameterList();

        return result;
    }
}

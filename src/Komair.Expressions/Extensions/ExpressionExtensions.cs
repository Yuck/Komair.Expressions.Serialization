using System.Collections.Generic;
using System.Linq.Expressions;

namespace Komair.Expressions.Extensions
{
    public static class ExpressionExtensions
    {
        public static IReadOnlyCollection<ParameterExpression> GetParameterList(this BinaryExpression expression)
        {
            if (expression == null)
                return new List<ParameterExpression>(); // TODO: Test to cover this rare condition

            var result = new List<ParameterExpression>();

            result.AddRange(expression.Left.GetParameterList());
            result.AddRange(expression.Right.GetParameterList());

            return result;
        }

        public static IReadOnlyCollection<ParameterExpression> GetParameterList(this Expression expression)
        {
            if (expression == null)
                return new List<ParameterExpression>(); // TODO: Test to cover this rare condition

            switch (expression)
            {
                case BinaryExpression binary:
                    return binary.GetParameterList();
                case MemberExpression member:
                    return member.GetParameterList();
                case ParameterExpression parameter:
                    return new List<ParameterExpression> { parameter };
            }

            return new List<ParameterExpression>();
        }

        public static IReadOnlyCollection<ParameterExpression> GetParameterList(this MemberExpression expression)
        {
            return expression == null
                       ? new List<ParameterExpression>()
                       : expression.Expression.GetParameterList();
        }
    }
}
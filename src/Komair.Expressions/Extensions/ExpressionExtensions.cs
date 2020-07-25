﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace Komair.Expressions.Extensions
{
    public static class ExpressionExtensions
    {
        public static IReadOnlyCollection<ParameterExpression> GetParameterList(this BinaryExpression expression)
        {
            if (expression == null)
                return new List<ParameterExpression>();

            var result = new List<ParameterExpression>();

            result.AddRange(expression.Left.GetParameterList());
            result.AddRange(expression.Right.GetParameterList());

            return result;
        }

        public static IReadOnlyCollection<ParameterExpression> GetParameterList(this Expression expression)
        {
            if (expression == null)
                return new List<ParameterExpression>();

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
            if (expression == null)
                return new List<ParameterExpression>();

            return expression.Expression.GetParameterList();
        }
    }
}
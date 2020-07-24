using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster
{
    public class MapsterExpressionNodeMapper<T, TResult> : IExpressionNodeMapper<T, TResult>
    {
        private readonly TypeAdapterConfig _configuration;

        public MapsterExpressionNodeMapper(TypeAdapterConfig configuration = null)
        {
            _configuration = configuration ?? new DefaultTypeAdapterConfiguration<T, TResult>();
        }

        public Expression<Func<T, TResult>> ToExpression(ExpressionNode expression)
        {
            // TODO: This is what has to be reconstructed
            //var type = typeof(T);
            //var parameter = Expression.Parameter(type, "t");
            //var memberInfo = type.GetMember("Length").First();
            //var left = Expression.MakeMemberAccess(parameter, memberInfo);
            //var right = Expression.Constant(10);
            //var body = Expression.GreaterThan(left, right);

            //var lammy = Expression.Lambda<Func<T, TResult>>(body, parameter);

            //return lammy;

            return expression.Adapt<Expression<Func<T, TResult>>>(_configuration);
        }

        public ExpressionNode ToExpressionNode(Expression<Func<T, TResult>> expression)
        {
            return expression.Adapt<ExpressionNode>(_configuration);
        }
    }
}
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

        public Expression<Func<T, TResult>> ToExpression(ExpressionNode expression) => expression.Adapt<Expression<Func<T, TResult>>>(_configuration);

        public ExpressionNode ToExpressionNode(Expression<Func<T, TResult>> expression) => expression.Adapt<ExpressionNode>(_configuration);
    }
}
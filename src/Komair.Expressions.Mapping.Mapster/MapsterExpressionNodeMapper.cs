using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster
{
    public class MapsterExpressionNodeMapper<T> : IExpressionNodeMapper<T>
    {
        private readonly TypeAdapterConfig _configuration;

        public MapsterExpressionNodeMapper(TypeAdapterConfig configuration = null)
        {
            _configuration = configuration ?? new DefaultTypeAdapterConfiguration<T>();
        }

        public Expression<T> ToExpression(ExpressionNode node) => node.Adapt<Expression<T>>(_configuration);

        public ExpressionNode ToExpressionNode(Expression<T> expression) => expression.Adapt<ExpressionNode>(_configuration);
    }
}
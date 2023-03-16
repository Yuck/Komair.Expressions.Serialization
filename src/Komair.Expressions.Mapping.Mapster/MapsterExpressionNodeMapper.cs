using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster;

public class MapsterExpressionNodeMapper<T> : IExpressionNodeMapper<T>
{
    private readonly TypeAdapterConfig _configuration;

    public MapsterExpressionNodeMapper(TypeAdapterConfig configuration = null)
    {
        _configuration = configuration ?? new DefaultTypeAdapterConfiguration<T>();
    }

    public Expression<T> ToExpression(ExpressionNodeBase node) => node.Adapt<Expression<T>>(_configuration);

    public ExpressionNodeBase ToExpressionNode(Expression<T> expression) => expression.Adapt<ExpressionNodeBase>(_configuration);
}

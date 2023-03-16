using Komair.Expressions.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;

internal abstract class ExpressionNodeMapperBase<TSource, TDestination> where TSource : ExpressionNodeBase where TDestination : LinqExpression
{
    protected TypeAdapterConfig Configuration;

    protected ExpressionNodeMapperBase(TypeAdapterConfig configuration)
    {
        Configuration = configuration;
    }

    public abstract TDestination Map(TSource source);
}

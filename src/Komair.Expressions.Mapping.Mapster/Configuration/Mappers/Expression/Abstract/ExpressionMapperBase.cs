using Komair.Expressions.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract
{
    internal abstract class ExpressionMapperBase<TSource, TDestination> where TSource : LinqExpression where TDestination : ExpressionNodeBase
    {
        protected TypeAdapterConfig Configuration;

        protected ExpressionMapperBase(TypeAdapterConfig configuration)
        {
            Configuration = configuration;
        }

        public abstract TDestination Map(TSource source);
    }
}
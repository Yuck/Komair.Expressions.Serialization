using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract
{
    internal abstract class ExpressionMapperBase<TSource, TDestination> where TSource : System.Linq.Expressions.Expression where TDestination : Expressions.Abstract.ExpressionNode
    {
        protected TypeAdapterConfig Configuration;

        protected ExpressionMapperBase(TypeAdapterConfig configuration)
        {
            Configuration = configuration;
        }

        public abstract TDestination Map(TSource source);
    }
}
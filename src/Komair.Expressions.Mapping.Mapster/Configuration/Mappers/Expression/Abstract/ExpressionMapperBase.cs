using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract
{
    internal abstract class ExpressionMapperBase<TSource, TDestination>
    {
        protected TypeAdapterConfig Configuration;

        protected ExpressionMapperBase(TypeAdapterConfig configuration)
        {
            Configuration = configuration;
        }

        public abstract TDestination Map(TSource source);
    }
}
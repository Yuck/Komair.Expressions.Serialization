using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract
{
    internal abstract class ExpressionNodeMapperBase<TSource, TDestination>
    {
        protected TypeAdapterConfig Configuration;

        protected ExpressionNodeMapperBase(TypeAdapterConfig configuration)
        {
            Configuration = configuration;
        }

        public abstract TDestination Map(TSource source);
    }
}
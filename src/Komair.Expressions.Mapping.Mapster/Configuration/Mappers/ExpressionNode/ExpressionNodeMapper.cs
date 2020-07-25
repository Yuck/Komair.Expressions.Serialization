using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ExpressionNodeMapper<T, TResult> : ExpressionNodeMapperBase<Expressions.Abstract.ExpressionNode, Expression<Func<T, TResult>>>
    {
        public ExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override Expression<Func<T, TResult>> Map(Expressions.Abstract.ExpressionNode source)
        {
            if (source is LambdaExpressionNode node)
                return new LambdaExpressionNodeMapper<T, TResult>(Configuration).Map(node);

            throw new NotSupportedException();
        }
    }
}
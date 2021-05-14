using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ExpressionNodeMapper<T> : ExpressionNodeMapperBase<Expressions.Abstract.ExpressionNode, Expression<T>>
    {
        public ExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expression<T> Map(Expressions.Abstract.ExpressionNode source)
        {
            var result = source is LambdaExpressionNode node
                             ? new LambdaExpressionNodeMapper<T>(Configuration).Map(node)
                             : throw new NotSupportedException();

            return result;
        }
    }
}
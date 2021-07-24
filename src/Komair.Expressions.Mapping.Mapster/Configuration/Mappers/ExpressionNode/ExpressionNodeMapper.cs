using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class ExpressionNodeMapper<T> : ExpressionNodeMapperBase<ExpressionNodeBase, Expression<T>>
    {
        public ExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expression<T> Map(ExpressionNodeBase source)
        {
            if (source is LambdaExpressionNode lambdaExpressionNode)
                return new LambdaExpressionNodeMapper<T>(Configuration).Map(lambdaExpressionNode);

            throw new NotSupportedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class LambdaExpressionMapper : ExpressionMapperBase<LambdaExpression, LambdaExpressionNode>
    {
        public LambdaExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override LambdaExpressionNode Map(LambdaExpression source)
        {
            var result = new LambdaExpressionNode(source.NodeType, source.Type)
            {
                // TODO: Should not have to pass Mapster Configuration around like this
                Body = source.Body.Adapt<Expressions.Abstract.ExpressionNode>(Configuration),
                Parameters = source.Parameters.Adapt<IEnumerable<ParameterExpressionNode>>(Configuration),
                ReturnType = source.ReturnType
            };

            return result;
        }
    }
}
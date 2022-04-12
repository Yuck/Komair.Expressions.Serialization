using System.Collections.Generic;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression;

internal class LambdaExpressionMapper : ExpressionMapperBase<LambdaExpression, LambdaExpressionNode>
{
    public LambdaExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

    public override LambdaExpressionNode Map(LambdaExpression source)
    {
        var nodeType = source.NodeType;
        var type = source.Type;
        var body = source.Body.Adapt<ExpressionNodeBase>(Configuration);
        var parameters = source.Parameters.Adapt<IReadOnlyCollection<ParameterExpressionNode>>(Configuration);
        var result = new LambdaExpressionNode(nodeType, type)
        {
            Body = body,
            Parameters = parameters
        };

        return result;
    }
}

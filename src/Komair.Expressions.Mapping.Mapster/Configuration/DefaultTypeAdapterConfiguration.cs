using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration;

internal class DefaultTypeAdapterConfiguration<T> : TypeAdapterConfig
{
    public DefaultTypeAdapterConfiguration()
    {
        ForType<Expression<T>, ExpressionNodeBase>().MapWith(source => new ExpressionMapper<T>(this).Map(source));
        ForType<BinaryExpression, ExpressionNodeBase>().MapWith(source => new BinaryExpressionMapper(this).Map(source));
        ForType<ConstantExpression, ExpressionNodeBase>().MapWith(source => new ConstantExpressionMapper(this).Map(source));
        ForType<MemberExpression, ExpressionNodeBase>().MapWith(source => new MemberExpressionMapper(this).Map(source));
        ForType<ParameterExpression, ExpressionNodeBase>().MapWith(source => new ParameterExpressionMapper(this).Map(source));
        ForType<ParameterExpression, ParameterExpressionNode>().MapWith(source => new ParameterExpressionMapper(this).Map(source));

        ForType<ExpressionNodeBase, Expression<T>>().MapWith(source => new ExpressionNodeMapper<T>(this).Map(source));
        ForType<BinaryExpressionNode, Expression>().MapWith(source => new BinaryExpressionNodeMapper(this).Map(source));
        ForType<ConstantExpressionNode, Expression>().MapWith(source => new ConstantExpressionNodeMapper(this).Map(source));
        ForType<MemberExpressionNode, Expression>().MapWith(source => new MemberExpressionNodeMapper(this).Map(source));
        ForType<ParameterExpressionNode, Expression>().MapWith(source => new ParameterExpressionNodeMapper(this).Map(source));
    }
}

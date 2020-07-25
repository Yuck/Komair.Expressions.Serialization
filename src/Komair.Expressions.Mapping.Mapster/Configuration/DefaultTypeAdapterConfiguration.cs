using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration
{
    internal class DefaultTypeAdapterConfiguration<T, TResult> : TypeAdapterConfig
    {
        public DefaultTypeAdapterConfiguration()
        {
            ForType<Expression<Func<T, TResult>>, ExpressionNode>().MapWith(source => new ExpressionMapper<T, TResult>(this).Map(source));
            ForType<BinaryExpression, ExpressionNode>().MapWith(source => new BinaryExpressionMapper(this).Map(source));
            ForType<ConstantExpression, ExpressionNode>().MapWith(source => new ConstantExpressionMapper(this).Map(source));
            ForType<MemberExpression, ExpressionNode>().MapWith(source => new MemberExpressionMapper(this).Map(source));
            ForType<ParameterExpression, ExpressionNode>().MapWith(source => new ParameterExpressionMapper(this).Map(source));
            ForType<ParameterExpression, ParameterExpressionNode>().MapWith(source => new ParameterExpressionMapper(this).Map(source));

            ForType<ExpressionNode, Expression<Func<T, TResult>>>().MapWith(source => new ExpressionNodeMapper<T, TResult>(this).Map(source));
            ForType<BinaryExpressionNode, Expression>().MapWith(source => new BinaryExpressionNodeMapper(this).Map(source));
            ForType<ConstantExpressionNode, Expression>().MapWith(source => new ConstantExpressionNodeMapper(this).Map(source));
            ForType<MemberExpressionNode, Expression>().MapWith(source => new MemberExpressionNodeMapper(this).Map(source));
            ForType<ParameterExpressionNode, Expression>().MapWith(source => new ParameterExpressionNodeMapper(this).Map(source));
        }
    }
}
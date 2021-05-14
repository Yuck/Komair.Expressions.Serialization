﻿using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class ExpressionMapper<T> : ExpressionMapperBase<Expression<T>, Expressions.Abstract.ExpressionNode>
    {
        public ExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override Expressions.Abstract.ExpressionNode Map(Expression<T> source)
        {
            var result = new LambdaExpressionMapper(Configuration).Map(source);

            return result;
        }
    }
}
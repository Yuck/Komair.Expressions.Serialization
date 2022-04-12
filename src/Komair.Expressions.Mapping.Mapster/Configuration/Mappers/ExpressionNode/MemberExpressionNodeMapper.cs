using System;
using System.Linq;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode;

internal class MemberExpressionNodeMapper : ExpressionNodeMapperBase<MemberExpressionNode, MemberExpression>
{
    public MemberExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

    public override MemberExpression Map(MemberExpressionNode source)
    {
        var expression = source.Expression.Adapt<LinqExpression>(Configuration);
        var type = source.Expression?.Type;
        if (type == null)
            throw new NullReferenceException();

        var member = type.GetMember(source.MemberName).FirstOrDefault();
        if (member == null)
            throw new MemberAccessException($"Member '{source.MemberName}' was not found on type '{type.FullName}'.");

        var result = LinqExpression.MakeMemberAccess(expression, member);

        return result;
    }
}

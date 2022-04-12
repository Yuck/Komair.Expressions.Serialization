using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions;

public class MemberExpressionNode : ExpressionNodeBase
{
    public ExpressionNodeBase Expression { get; set; }
    public String MemberName { get; set; }

    public MemberExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
}

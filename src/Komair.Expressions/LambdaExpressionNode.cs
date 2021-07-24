using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class LambdaExpressionNode : ExpressionNodeBase
    {
        public ExpressionNodeBase Body { get; set; }
        public IReadOnlyCollection<ParameterExpressionNode> Parameters { get; set; }

        public LambdaExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
    }
}
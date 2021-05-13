using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Extensions;
using Komair.Expressions.Mapping.Abstract;
using Komair.Expressions.Mapping.Mapster;
using Komair.Expressions.Serialization.Abstract;
using Komair.Expressions.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Komair.Expressions.Serialization.UnitTests
{
    // TODO: Break this into smaller unit tests
    public class ComprehensiveTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestEverything()
        {
            static IExpressionNodeMapper<String, Boolean> GetMapper() => new MapsterExpressionNodeMapper<String, Boolean>();
            static IExpressionNodeSerializer<JObject, ExpressionNode> GetSerializer() => new JsonExpressionNodeSerializer<ExpressionNode>(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            const String value = "test";

            var mapper = GetMapper(); // this would come via DI
            var serializer = GetSerializer(); // this would come via DI

            Expression<Func<String, Boolean>> expression1 = t => t.Length > 0;
            var test1 = expression1.Compile()(value);

            var node1 = mapper.ToExpressionNode(expression1);
            var serialized = serializer.Serialize(node1);
            var node2 = serializer.Deserialize(serialized);

            var expression2 = mapper.ToExpression(node2);
            var test2 = expression2.Compile()(value);

            Assert.AreEqual(test1, test2);
        }

        [Test]
        public void TestExpressionExtensions()
        {
            var a = GetNullReference<Expression>();
            var b = GetNullReference<BinaryExpression>();

            var x = a.GetParameterList();
            var y = b.GetParameterList();

            Assert.IsNotNull(x);
            Assert.IsEmpty(x);

            Assert.IsNotNull(y);
            Assert.IsEmpty(y);
        }

        [Test]
        public void TestMemberExpressionNodeMapper()
        {
            static IExpressionNodeMapper<String, String> GetMapper() => new MapsterExpressionNodeMapper<String, String>();

            var expressionType = ExpressionType.MemberAccess;
            var memberExpressionNode = new MemberExpressionNode(expressionType, typeof(String))
            {
                MemberName = "HelloWorld"
            };
            var lambdaExpressionNode = new LambdaExpressionNode(ExpressionType.Lambda, typeof(String))
            {
                Body = memberExpressionNode
            };

            var mapper = GetMapper(); // this would come via DI

            Assert.Throws<NullReferenceException>(() => mapper.ToExpression(lambdaExpressionNode));

            memberExpressionNode.Expression = new ConstantExpressionNode(ExpressionType.Constant, typeof(String));

            Assert.Throws<MemberAccessException>(() => mapper.ToExpression(lambdaExpressionNode));
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_Int32Int32()
        {
            static IExpressionNodeMapper<Int32, Int32> GetMapper() => new MapsterExpressionNodeMapper<Int32, Int32>();

            var operations = new[]
            {
                ExpressionType.Add, ExpressionType.AddAssign, ExpressionType.AddAssignChecked,
                ExpressionType.AddChecked, ExpressionType.And, ExpressionType.AndAssign,
                ExpressionType.Assign, ExpressionType.Divide, ExpressionType.DivideAssign,
                ExpressionType.ExclusiveOr, ExpressionType.ExclusiveOrAssign, ExpressionType.LeftShift, ExpressionType.LeftShiftAssign,
                ExpressionType.Modulo, ExpressionType.ModuloAssign, ExpressionType.Multiply, ExpressionType.MultiplyAssign, ExpressionType.MultiplyAssignChecked,
                ExpressionType.MultiplyChecked, ExpressionType.Or, ExpressionType.OrAssign,
                ExpressionType.RightShift, ExpressionType.RightShiftAssign, ExpressionType.Subtract, ExpressionType.SubtractAssign,
                ExpressionType.SubtractAssignChecked, ExpressionType.SubtractChecked
            };
            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(Int32)) { Name = "t" };

            foreach (var operation in operations)
            {
                var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(Int32))
                {
                    Body = new BinaryExpressionNode(operation, typeof(Int32)) { Left = parameter, Right = parameter },
                    Parameters = new List<ParameterExpressionNode> { parameter }
                };
                var expression = mapper.ToExpression(node);

                Assert.IsNotNull(expression);
            }
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_Int32Boolean()
        {
            static IExpressionNodeMapper<Int32, Boolean> GetMapper() => new MapsterExpressionNodeMapper<Int32, Boolean>();

            var operations = new[]
            {
                ExpressionType.Equal, ExpressionType.GreaterThan, ExpressionType.GreaterThanOrEqual,
                ExpressionType.LessThan, ExpressionType.LessThanOrEqual, ExpressionType.NotEqual
            };
            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(Int32)) { Name = "t" };

            foreach (var operation in operations)
            {
                var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(Int32))
                {
                    Body = new BinaryExpressionNode(operation, typeof(Int32)) { Left = parameter, Right = parameter },
                    Parameters = new List<ParameterExpressionNode> { parameter }
                };
                var expression = mapper.ToExpression(node);

                Assert.IsNotNull(expression);
            }
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_BooleanBoolean()
        {
            static IExpressionNodeMapper<Boolean, Boolean> GetMapper() => new MapsterExpressionNodeMapper<Boolean, Boolean>();

            var operations = new[]
            {
                ExpressionType.AndAlso, ExpressionType.OrElse
            };
            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(Boolean)) { Name = "t" };

            foreach (var operation in operations)
            {
                var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(Boolean))
                {
                    Body = new BinaryExpressionNode(operation, typeof(Boolean)) { Left = parameter, Right = parameter },
                    Parameters = new List<ParameterExpressionNode> { parameter }
                };
                var expression = mapper.ToExpression(node);

                Assert.IsNotNull(expression);
            }
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_DoubleDouble()
        {
            static IExpressionNodeMapper<Double, Double> GetMapper() => new MapsterExpressionNodeMapper<Double, Double>();

            var operations = new[]
            {
                ExpressionType.Power, ExpressionType.PowerAssign
            };
            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(Double)) { Name = "t" };

            foreach (var operation in operations)
            {
                var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(Double))
                {
                    Body = new BinaryExpressionNode(operation, typeof(Double)) { Left = parameter, Right = parameter },
                    Parameters = new List<ParameterExpressionNode> { parameter }
                };
                var expression = mapper.ToExpression(node);

                Assert.IsNotNull(expression);
            }
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_Coalesce()
        {
            static IExpressionNodeMapper<String, String> GetMapper() => new MapsterExpressionNodeMapper<String, String>();

            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(String)) { Name = "t" };
            var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(String))
            {
                Body = new BinaryExpressionNode(ExpressionType.Coalesce, typeof(String)) { Left = parameter, Right = parameter },
                Parameters = new List<ParameterExpressionNode> { parameter }
            };
            var expression = mapper.ToExpression(node);

            Assert.IsNotNull(expression);
        }

        [Test]
        public void TestBinaryExpressionNodeMapper_NotSupported()
        {
            static IExpressionNodeMapper<String, String> GetMapper() => new MapsterExpressionNodeMapper<String, String>();

            var mapper = GetMapper();
            var parameter = new ParameterExpressionNode(ExpressionType.Parameter, typeof(String)) { Name = "t" };
            var node = new LambdaExpressionNode(ExpressionType.Lambda, typeof(String))
            {
                Body = new BinaryExpressionNode(ExpressionType.ArrayIndex, typeof(String)) { Left = parameter, Right = parameter },
                Parameters = new List<ParameterExpressionNode> { parameter }
            };

            Assert.Throws<NotSupportedException>(() => mapper.ToExpression(node));
        }

        private static T GetNullReference<T>() where T : class => null;
    }
}
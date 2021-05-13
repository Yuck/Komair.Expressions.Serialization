using System;
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

        private static T GetNullReference<T>() where T : class => null;
    }
}
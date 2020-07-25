using System;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Abstract;
using Komair.Expressions.Mapping.Mapster;
using Komair.Expressions.Serialization.Abstract;
using Komair.Expressions.Serialization.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Komair.Expressions.Serialization.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Func<IExpressionNodeMapper<string, bool>> getMapper = () => new MapsterExpressionNodeMapper<string, bool>();
            Func<IExpressionNodeSerializer<JObject, LambdaExpressionNode>> getSerializer = () => new JsonExpressionTreeSerializer<LambdaExpressionNode>();
            Expression<Func<string, bool>> x = t => t.Length > 0;

            var value = "test";
            var test1 = x.Compile()(value);

            var mapper = getMapper(); // this would come via DI
            var serializer = getSerializer(); // this would come via DI

            var tree1 = mapper.ToExpressionNode(x) as LambdaExpressionNode;
            var serialized = serializer.Serialize(tree1).ToString();

            var deserialized = serializer.Deserialize(JObject.Parse(serialized));
            var tree2 = mapper.ToExpression(deserialized);

            var xxx = tree2.Compile();

            var test2 = xxx(value);

            Assert.AreEqual(test1, test2);
        }
    }
}
using System.Collections.Generic;
using Komair.Expressions.Abstract;
using Komair.Expressions.Serialization.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Komair.Expressions.Serialization.Json
{
    public class JsonExpressionTreeSerializer<TExpressionNode> : IExpressionNodeSerializer<JObject, TExpressionNode> where TExpressionNode : ExpressionNode
    {
        private readonly JsonSerializerSettings _defaultSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto
        };

        private readonly JsonSerializer _serializer;

        public JsonExpressionTreeSerializer(JsonSerializer serializer = null)
        {
            _serializer = serializer ?? JsonSerializer.Create(_defaultSettings);
        }

        public TExpressionNode Deserialize(JObject document)
        {
            return document.ToObject<TExpressionNode>(_serializer);
        }

        public JObject Serialize(TExpressionNode tree)
        {
            return JObject.FromObject(tree, _serializer);
        }
    }
}
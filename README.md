# Komair.Expressions.Serialization

A .NET library ecosystem for **serializing and deserializing LINQ expression trees**. It provides serializable equivalents of `System.Linq.Expressions` classes, enabling expressions to be converted to and from wire formats (such as JSON), stored, transmitted, and restored as fully executable LINQ expressions.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Packages

| Package | Description |
|---------|-------------|
| **Komair.Expressions** | Core library providing serializable equivalents of `System.Linq.Expressions` types. |
| **Komair.Expressions.Mapping** | Abstraction for mapping between `ExpressionNodeBase` and `Expression<T>`. |
| **Komair.Expressions.Mapping.Mapster** | Mapping implementation using [Mapster](https://github.com/MapsterMapper/Mapster). |
| **Komair.Expressions.Serialization** | Abstraction for serializing/deserializing `ExpressionNodeBase` to a transport format. |
| **Komair.Expressions.Serialization.Json** | Serialization implementation using [Newtonsoft.Json](https://www.newtonsoft.com/json). |

All packages target **.NET 8.0**.

## Architecture

```
LINQ Expression<T>
  │
  ▼  IExpressionNodeMapper<T>
ExpressionNodeBase (serializable)
  │
  ▼  IExpressionNodeSerializer<T, TExpressionNode>
Transport format (e.g. JObject)
```

Expressions flow through two layers:

1. **Mapping** — converts between executable `Expression<T>` and the serializable `ExpressionNodeBase` graph.
2. **Serialization** — converts between `ExpressionNodeBase` and a transport format such as JSON.

Both layers are defined as abstractions with pluggable implementations.

## Getting Started

### Installation

Install the packages you need via NuGet:

```shell
# Core + Mapster mapping + JSON serialization (most common)
dotnet add package Komair.Expressions.Mapping.Mapster
dotnet add package Komair.Expressions.Serialization.Json
```

### Quick Example

```csharp
using Komair.Expressions;
using Komair.Expressions.Mapping.Mapster;
using Komair.Expressions.Serialization.Json;
using Newtonsoft.Json;

// 1. Create a mapper and serializer
var mapper = new MapsterExpressionNodeMapper<Func<string, bool>>();
var serializer = new JsonExpressionNodeSerializer<ExpressionNodeBase>(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

// 2. Start with a LINQ expression
Expression<Func<string, bool>> expression = t => t.Length > 0;

// 3. Convert to a serializable node, then to JSON
ExpressionNodeBase node = mapper.ToExpressionNode(expression);
JObject json = serializer.Serialize(node);

// 4. Deserialize and map back to an executable expression
ExpressionNodeBase restored = serializer.Deserialize(json);
Expression<Func<string, bool>> result = mapper.ToExpression(restored);

// 5. Compile and run
bool value = result.Compile()("hello"); // true
```

## Core Types

### ExpressionNodeBase

Abstract base class for all serializable expression nodes. Each node mirrors a corresponding `System.Linq.Expressions` type:

| Node Class | Represents | Key Properties |
|---|---|---|
| `LambdaExpressionNode` | Lambda expressions (`t => ...`) | `Body`, `Parameters` |
| `BinaryExpressionNode` | Binary operations (`+`, `==`, `&&`, …) | `Left`, `Right` |
| `ConstantExpressionNode` | Constant values (`5`, `"hello"`, `true`) | `Value` |
| `ParameterExpressionNode` | Parameters (`x`, `y`) | `Name` |
| `MemberExpressionNode` | Member access (`t.Length`) | `Expression`, `MemberName` |

All nodes carry `NodeType` (the `ExpressionType` enum value) and `Type` (the CLR type of the expression result).

### IExpressionNodeMapper&lt;T&gt;

Abstraction for converting between `Expression<T>` and `ExpressionNodeBase`:

```csharp
public interface IExpressionNodeMapper<T>
{
    Expression<T> ToExpression(ExpressionNodeBase node);
    ExpressionNodeBase ToExpressionNode(Expression<T> expression);
}
```

**Provided implementation:** `MapsterExpressionNodeMapper<T>` (uses Mapster for the mapping logic).

### IExpressionNodeSerializer&lt;T, TExpressionNode&gt;

Abstraction for serializing expression nodes to/from a transport format:

```csharp
public interface IExpressionNodeSerializer<T, TExpressionNode> where TExpressionNode : ExpressionNodeBase
{
    TExpressionNode Deserialize(T document);
    T Serialize(TExpressionNode node);
}
```

**Provided implementation:** `JsonExpressionNodeSerializer<TExpressionNode>` (serializes to/from `Newtonsoft.Json.Linq.JObject`).

## Supported Binary Operations

The Mapster mapping layer supports a wide range of binary expression types:

| Category | Operations |
|---|---|
| **Arithmetic** | Add, Subtract, Multiply, Divide, Modulo, Power |
| **Logical** | And, AndAlso, Or, OrElse, ExclusiveOr |
| **Comparison** | Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual |
| **Assignment** | Assign, AddAssign, SubtractAssign, MultiplyAssign, DivideAssign, ModuloAssign, PowerAssign, AndAssign, OrAssign, ExclusiveOrAssign |
| **Checked** | AddChecked, SubtractChecked, MultiplyChecked, AddAssignChecked, SubtractAssignChecked, MultiplyAssignChecked |
| **Other** | Coalesce, LeftShift, RightShift, LeftShiftAssign, RightShiftAssign |

## Building Multiple Parameters

You can construct expression nodes manually for multi-parameter lambdas:

```csharp
var paramT = new ParameterExpressionNode
{
    Name = "t",
    // set NodeType and Type accordingly
};

var paramU = new ParameterExpressionNode
{
    Name = "u",
};

var body = new BinaryExpressionNode(ExpressionType.Add)
{
    Left = paramT,
    Right = paramU
};

var lambda = new LambdaExpressionNode
{
    Body = body,
    Parameters = new[] { paramT, paramU }
};
```

## Extension Methods

`ExpressionExtensions` provides helpers for extracting parameters from expression trees:

```csharp
// Get all unique parameters from any expression
IReadOnlyCollection<ParameterExpression> parameters = expression.GetParameterList();
```

## Authors

- Kevin J Lambert
- Omair Sajid

## License

This project is licensed under the [MIT License](LICENSE).

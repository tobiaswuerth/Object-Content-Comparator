# Object-Content-Compartor

Compare objects of any type based on their property values.

## Download
:white_check_mark: .net core v2.0\
:white_check_mark: .net framework v4.6\
**[Download latest release here](https://github.com/tobiaswuerth/Object-Content-Comparator/releases/tag/v0.1)**

## How does it work?

The object is serialized into JSON (properties can be labled using the attributes `[JsonProperty]` and `[JsonIgnore]`) which then is hashed using the SHA512 Algorithm. The objects are compared by comparing their hashes which does **not** guarantee that every content generates a unique hash ... but pretty much. [Click here](https://en.wikipedia.org/wiki/Pigeonhole_principle) to find out more.

## Dependencies

[Newtonsoft Json.NET](https://www.newtonsoft.com/json) Nuget package

# Usage
```csharp
var obj1 = new MyStatelessClass();
var obj2 = new MyStatelessClass();

Comparator.AreEqual(obj1, obj2);
>>> true

Comparator.AreEqual(15, "15"); // this is because string "15" and integer 15 are not considered equal
>>> false

Comparator.AreEqual(DateTime.MinValue, DateTime.Parse("01/01/0001 00:00:00"));
>>> true
```

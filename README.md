# Serialization of a List of `object` instances in Unity

This project provides the functionality of serializing a list of object instances inside of Unity.

## Why
When working with reflection and editor scripting I sometimes want to serialize a list of values of arbitrary types.

If you want to serialize a list that contains `int`, `float`, `Vector3`, `Color` or other types that are usually serializable in Unity, you might want to create a `List<object>` to hold these values. However, Unity will not be able to serialize this list.

## What the plugin does
The `SerializationContainer` class internally serializes a value as a `string` which can be later deserialized. It allows for serialization of any type Unity allows serialization for by default.

```csharp
var serializedValue = SerializationContainer.From(100);
Debug.Log(serializedValue.StoredType);
// Value deserializes the stored value and returns it as object instance
Debug.Log(serializedValue.Value);
Debug.Log(serializedValue.Is<int>());

// You can also cast the value
int deserializedValue = serializedValue.GetValue<int>();
```

> System.Int32\
> 100\
> true

If you now need a list of arbitrary typed instances, you could just create a `List<SerializationContainer>`. The project also contains a `SerializableList`. It can be used like this:

```csharp
public class SerializationExample : MonoBehaviour
{
    [SerializeField] private SerializableList _objects = new SerializableList(100, "foo", Color.red);

    public SerializableList Objects => _objects;
}
```

`SerializableList` implementes `IEnumerable<SerializationContainer>`. Values can be added using the constructor or the `Add`-Method, which also takes an `object` instance.

## What it doesn't do
This project doesn't allow you to serialize any kind of object that Unity can not already serialize.

## Installation

Download the [Package](https://github.com/Moolt/UnityObjectListSerialization/raw/master/UnityObjectListSerialization.unitypackage).

Assets > Import Package > Custom Package ...

```csharp 
using ObjectSerialization;
```
using ObjectSerialization;
using UnityEngine;

public class SerializationExample : MonoBehaviour
{
    [SerializeField] private SerializableList _objects = new SerializableList(100, "foo", Color.red);

    public SerializableList Objects => _objects;
}

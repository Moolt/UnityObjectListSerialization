using ObjectSerialization;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SerializationExample))]
public class SerializationExampleInspector : Editor
{
    private SerializationExample _target;

    private void OnEnable()
    {
        _target = target as SerializationExample;
    }

    public override void OnInspectorGUI()
    {
        foreach (var obj in _target.Objects)
        {
            if (obj.Is<int>())
            {
                obj.Value = EditorGUILayout.IntField(obj.GetValue<int>());
                continue;
            }

            if (obj.Is<string>())
            {
                obj.Value = EditorGUILayout.TextField(obj.GetValue<string>());
                continue;
            }

            if (obj.Is<float>())
            {
                obj.Value = EditorGUILayout.FloatField(obj.GetValue<float>());
                continue;
            }

            if (obj.Is<Color>())
            {
                obj.Value = EditorGUILayout.ColorField(obj.GetValue<Color>());
                continue;
            }

            // Can be extended for other types.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value by default when starting")]
    public Vector2 initialValue;

    [Header("Value running in game")]
    [HideInInspector]
    public Vector2 runtimeValue;
    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}

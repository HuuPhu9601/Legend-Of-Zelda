using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject,ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float runtimeValue;
    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}

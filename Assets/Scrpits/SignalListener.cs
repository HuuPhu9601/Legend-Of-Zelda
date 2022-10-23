using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public HealthSignal signal;
    //Tạo ra một sự kiện unityEvent
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    //Sử dụng hàm enable có sẵn của unity
    private void OnEnable()
    {
        signal.RegisterListener(this);     
    }

    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Void Event")]
public class VoidEvent : ScriptableObject
{
    public Action gameEvent;

    public void RaiseEvent()
    {
        gameEvent?.Invoke();
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "State Event")]
public class PlayerStateEvent : ScriptableObject
{
    public Action<PlayerState> gameEvent;

    public void RaiseEvent(PlayerState playerState)
    {
        gameEvent?.Invoke(playerState);
    }
}

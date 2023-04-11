using System;
using UnityEngine;

public abstract class Turn : MonoBehaviour
{
    public event Action OnFinishedTurn;

    public abstract void StartTurn();

    public abstract void StopWork();

    protected void StartEventFinishedTurn()
    {
        OnFinishedTurn?.Invoke();
    }
}

using System;
using UnityEngine;

public abstract class Turn : MonoBehaviour
{
    public event Action OnFinishedTurn;

    public abstract void StartTurn();

    protected void StartEventFinishedTurn()
    {
        OnFinishedTurn?.Invoke();
    }
}

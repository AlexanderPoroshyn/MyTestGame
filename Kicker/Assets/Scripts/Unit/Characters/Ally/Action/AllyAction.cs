using System;
using UnityEngine;

public abstract class AllyAction : MonoBehaviour
{
    public event Action OnStartedAction, OnFinishedAction;
    [SerializeField] protected AllyActionPoint[] allyActionPoints;

    protected void SubscribeEvents()
    {
        for (int i = 0; i < allyActionPoints.Length; i++)
        {
            allyActionPoints[i].OnClicked += StartAction;
        }
    }

    protected void SetActivePoints(bool active)
    {
        for (int i = 0; i < allyActionPoints.Length; i++)
        {
            allyActionPoints[i].gameObject.SetActive(active);
        }
    }

    public void AllowAction()
    {
        SetActivePoints(true);
    }

    public void ProhibitAction()
    {
        SetActivePoints(false);
    }

    protected abstract void StartAction(Vector2 pointPosition);

    protected void StartEventStartedAction()
    {
        OnStartedAction?.Invoke();
    }

    protected void StartEventFinishedAction()
    {
        OnFinishedAction?.Invoke();
    }
}

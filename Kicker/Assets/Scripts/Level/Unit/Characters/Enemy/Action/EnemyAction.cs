using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyAction : MonoBehaviour
{
    private PlaceSorter selectPoint;
    [SerializeField] private PlaceSorter[] generalActionPoint;
    [SerializeField] private PlaceSorter[] simpleActionPoints;

    public event Action OnFinishedAction;

    public bool TryDoAction()
    {
        if (SelectPointsAndTryStartAction(generalActionPoint) == true)
        {
            return true;
        }
        else if(SelectPointsAndTryStartAction(simpleActionPoints) == true)
        {
            return true;
        }
        return false;
    }

    private bool SelectPointsAndTryStartAction(PlaceSorter[] placeSorters)
    {
        selectPoint = GetPlaceSorter(placeSorters);
        if (selectPoint != null)
        {
            StartAction();
            return true;
        }
        return false;
    }

    private PlaceSorter GetPlaceSorter(PlaceSorter[] placeSorters)
    {
        List<PlaceSorter> activePoints = new List<PlaceSorter>();

        for (int i = 0; i < placeSorters.Length; i++)
        {
            if (placeSorters[i].CheckRequirements() == true)
            {
                activePoints.Add(placeSorters[i]);
            }
        }
        if (activePoints.Count != 0)
        {
            int randomPoint = UnityEngine.Random.Range(0, activePoints.Count);
            return activePoints[randomPoint];
        }
        return null;
    }

    private void StartAction()
    {
        DoAction(selectPoint.transform.position);
    }

    protected abstract void DoAction(Vector2 pointPosition);

    protected void StartEventFinishedAction()
    {
        OnFinishedAction?.Invoke();
    }
}

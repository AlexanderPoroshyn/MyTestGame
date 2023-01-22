using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int countSteps;
    private int countStepsLeft;

    [SerializeField] private EnemyAction[] enemyActions;
    private EnemyAction selectedAction;
    public event Action OnFinishedAction;

    private void Awake()
    {
        SubscribeEvents();
        for (int i = 0; i < enemyActions.Length; i++)
        {
            enemyActions[i].OnFinishedAction += MakeAction;
        }
    }

    public void MakeStep()
    {
        countStepsLeft = countSteps;
        MakeAction();
    }

    private void MakeAction()
    {
        if (countStepsLeft > 0)
        {
            for (int i = 0; i < enemyActions.Length; i++)
            {
                if (enemyActions[i].TryDoAction() == true)
                {
                    countStepsLeft -= 1;
                    return;
                }
            }
        }
        OnFinishedAction?.Invoke();
    }

    protected override void Die()
    {
        StartEventOnDied(this);
    }
}

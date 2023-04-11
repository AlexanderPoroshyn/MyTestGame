using System;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AccumulationEnemies))]
public class EnemyActivator : MonoBehaviour
{
    public event Action OnActivationFinished;

    private List<Enemy> enemies;
    private Enemy activatedEnemy;
    private int countEnemies, countActivatedEnemies;

    private AccumulationEnemies accumulationEnemies => GetComponent<AccumulationEnemies>();

    public bool IsCanWork = true;

    public void Activate()
    {
        enemies = accumulationEnemies.GetEnemies();
        if (enemies.Count != 0)
        {
            countEnemies = enemies.Count;
            countActivatedEnemies = 0;
            EnemyDoAction();
        }
        else
        {
            OnActivationFinished?.Invoke();
        }
    }

    private void EnemyDoAction()
    {
        if (countEnemies > countActivatedEnemies && IsCanWork == true)
        {
            activatedEnemy = enemies[countActivatedEnemies];
            activatedEnemy.OnFinishedAction += EnemyFinishedAction;
            activatedEnemy.MakeStep();
        }
        else
        {
            OnActivationFinished?.Invoke();
        }
    }

    private void EnemyFinishedAction()
    {
        activatedEnemy.OnFinishedAction -= EnemyFinishedAction;
        countActivatedEnemies += 1;
        EnemyDoAction();
    }
}

using UnityEngine;

[RequireComponent(typeof(EnemyCreator), typeof(EnemyActivator))]
public class ComputerTurn : Turn
{
    private EnemyCreator enemyCreator => GetComponent<EnemyCreator>();
    private EnemyActivator enemyActivator => GetComponent<EnemyActivator>();

    private void Awake()
    {
        enemyActivator.OnActivationFinished += StartEventFinishedTurn;
    }

    public override void StartTurn()
    {
        enemyCreator.DoAction();
        enemyActivator.Activate();
    }

    public override void StopWork()
    {
        enemyActivator.IsCanWork = false;
    }
}

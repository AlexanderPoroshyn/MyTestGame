using UnityEngine;

public class EnemyAttacker : EnemyAction
{
    [SerializeField] private DamageGiver explotion;

    protected override void DoAction(Vector2 pointPosition)
    {
        Instantiate(explotion, pointPosition, Quaternion.identity);

        Invoke(nameof(StartEventFinishedAction), 0.25f);
    }
}

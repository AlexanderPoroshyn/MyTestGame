using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class EnemyMover : EnemyAction
{
    private CharacterMover characterMover => GetComponent<CharacterMover>();

    private void Awake()
    {
        characterMover.OnFinishedMove += StartEventFinishedAction;
    }

    protected override void DoAction(Vector2 pointPosition)
    {
        characterMover.StartMove(pointPosition);
    }
}

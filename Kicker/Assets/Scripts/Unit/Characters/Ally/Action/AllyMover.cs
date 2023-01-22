using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class AllyMover : AllyAction
{
    private CharacterMover characterMover => GetComponent<CharacterMover>();

    private void Awake()
    {
        SubscribeEvents();
        characterMover.OnFinishedMove += StartEventFinishedAction;
    }

    protected override void StartAction(Vector2 pointPosition)
    {
        SetActivePoints(false);
        StartEventStartedAction();

        characterMover.StartMove(pointPosition);
    }
}

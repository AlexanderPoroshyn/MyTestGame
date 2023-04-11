using UnityEngine;

public class AllyAttacker : AllyAction
{
    [SerializeField] private DamageGiver explotion;

    private void Awake()
    {
        SubscribeEvents();
    }

    protected override void StartAction(Vector2 pointPosition)
    {
        SetActivePoints(false);
        StartEventStartedAction();
        Instantiate(explotion, pointPosition, Quaternion.identity);

        Invoke(nameof(FinishAction), 0.25f);
    }

    private void FinishAction()
    {
        StartEventFinishedAction();
    }
}

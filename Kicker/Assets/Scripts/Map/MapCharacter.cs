using UnityEngine;

public class MapCharacter : MonoBehaviour
{
    [SerializeField] private MapCharacterMover mapCharacterMover;
    [SerializeField] private MapCharacterSelector mapCharacterSelector;

    private void Awake()
    {
        mapCharacterMover.OnStartedMove += Moving;
        mapCharacterMover.OnFinishedMove += StopMoving;

        mapCharacterSelector.OnSelected += Selecting;

        UpdateChecking();
    }

    private void Moving()
    {
        mapCharacterSelector.enabled = false;
    }

    private void StopMoving()
    {
        mapCharacterSelector.enabled = true;

        UpdateChecking();
    }

    private void Selecting()
    {
        mapCharacterMover.enabled = false;
    }

    private void UpdateChecking()
    {
        mapCharacterMover.CheckAvailableDirections();
        mapCharacterSelector.CheckPointsForSelect();
    }
}

using UnityEngine;

[RequireComponent(typeof(MapCharacterMover), typeof(MapCharacterSelector), typeof(MapCharacterAppearance))]
public class MapCharacter : MonoBehaviour
{
    private MapCharacterMover mapCharacterMover => GetComponent<MapCharacterMover>();
    private MapCharacterSelector mapCharacterSelector => GetComponent<MapCharacterSelector>();
    private MapCharacterAppearance mapCharacterAppearance => GetComponent<MapCharacterAppearance>();

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
        mapCharacterAppearance.StartAnimationMove();
    }

    private void StopMoving()
    {
        mapCharacterSelector.enabled = true;
        mapCharacterAppearance.StartAnimationIdle();

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

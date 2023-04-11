using UnityEngine;

[RequireComponent(typeof(PlaceSorter))]
public class SpawnCellEnemy : MonoBehaviour
{
    private PlaceSorter placeSorter => GetComponent<PlaceSorter>();

    public bool IsCanSpawn(string layerName)
    {
        return placeSorter.CheckRequirements();
    }
}

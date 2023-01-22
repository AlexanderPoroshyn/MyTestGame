using UnityEngine;

public class SpawnCellEnemy : MonoBehaviour
{
    public bool IsCanSpawn(string layerName)
    {
        return !Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask(layerName));
    }
}

using UnityEngine;

public class Place : MonoBehaviour
{
    private Vector2 raycastPosition;
    
    public PlaceType GetPlace(Vector2 checkPosition)
    {
        raycastPosition = checkPosition;
        if (RaycastHit("Ally") == true)
        {
            return PlaceType.Ally;
        }
        if (RaycastHit("Enemy") == true)
        {
            return PlaceType.Enemy;
        }
        if (RaycastHit("Obstacle") == true)
        {
            return PlaceType.Obstacle;
        }
        if (RaycastHit("SpawnCellAlly") == true)
        {
            return PlaceType.SpawnCellAlly;
        }
        if (RaycastHit("SpawnCellEnemy") == true)
        {
            return PlaceType.SpawnCellEnemy;
        }
        if (RaycastHit("Cell") == true)
        {
            return PlaceType.Cell;
        }
        return PlaceType.None;
    }

    private bool RaycastHit(string layerName)
    {
        return Physics2D.Raycast(raycastPosition, Vector2.zero, 10f, LayerMask.GetMask(layerName));
    }

    public enum PlaceType
    {
        Cell,
        Ally,
        Obstacle,
        Enemy,
        SpawnCellAlly,
        SpawnCellEnemy,
        None
    }
}

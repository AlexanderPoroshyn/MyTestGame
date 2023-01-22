using UnityEngine;

public class PlaceChecker : MonoBehaviour
{
    public PlaceType GetPlace()
    {
        if(RaycastHit("Ally") == true)
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
        if (RaycastHit("Cell") == true)
        {
            return PlaceType.Cell;
        }
        return PlaceType.None;
    }

    private bool RaycastHit(string layerName)
    {
        return Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask(layerName));
    }

    public enum PlaceType
    {
        Cell,
        Ally,
        Obstacle,
        Enemy,
        None
    }
}

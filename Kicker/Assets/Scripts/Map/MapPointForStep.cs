using UnityEngine;

public class MapPointForStep : MonoBehaviour
{
    [SerializeField] private MapPointForStep directionUp, directionLeft, directionRight, directionDown;

    public MapPointForStep GetDirectionUp()
    {
        return directionUp;
    }
    public MapPointForStep GetDirectionLeft()
    {
        return directionLeft;
    }
    public MapPointForStep GetDirectionRight()
    {
        return directionRight;
    }
    public MapPointForStep GetDirectionDown()
    {
        return directionDown;
    }
}

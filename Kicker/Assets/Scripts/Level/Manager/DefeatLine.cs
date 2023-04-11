using UnityEngine;

public class DefeatLine : MonoBehaviour
{
    private Vector2 rayDirection = Vector2.down;
    private RaycastHit2D raycastHit2D;

    [SerializeField] private float distance;

    private void Start()
    {
         Debug.DrawRay(transform.position, rayDirection * distance, Color.red, 999f);
    }

    public bool CheckEnemies()
    {
        raycastHit2D = Physics2D.Raycast(transform.position, rayDirection, distance, LayerMask.GetMask("Enemy"));
        return raycastHit2D;
    }
}

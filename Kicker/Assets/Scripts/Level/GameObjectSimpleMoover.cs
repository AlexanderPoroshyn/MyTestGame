using UnityEngine;

public class GameObjectSimpleMoover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 direction;

    [Range(-1f, 1f)]
    [SerializeField] private float directionSpeedXMin, directionSpeedXMax;
    private float directionSpeedX;

    [Range(-1f, 1f)]
    [SerializeField] private float directionSpeedYMin, directionSpeedYMax;
    private float directionSpeedY;

    private void Start()
    {
        directionSpeedX = Random.Range(directionSpeedXMin, directionSpeedXMax);
        directionSpeedY = Random.Range(directionSpeedYMin, directionSpeedYMax);
        direction = new Vector3(directionSpeedX, directionSpeedY);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
}

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int chance;
    private int randomCount;

    [SerializeField] private Obstacle obstacle;

    public void Awake()
    {
        randomCount = Random.Range(1, 101);
        if(chance >= randomCount)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

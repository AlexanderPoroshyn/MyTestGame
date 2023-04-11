using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    [SerializeField] private float timeRateMin, timeRateMax;
    [SerializeField] private float IndentPositionXMin, IndentPositionXMax;
    [SerializeField] private float IndentPositionYMin, IndentPositionYMax;

    [SerializeField] private GameObject gameObjectForSpawn;

    [SerializeField] private bool IsLoop;

    private void Start()
    {
        Invoke(nameof(CreateObject), timeRateMin);
    }

    private void CreateObject()
    {
        float positionX = Random.Range(IndentPositionXMin, IndentPositionXMax) + gameObject.transform.position.x;
        float positionY = Random.Range(IndentPositionYMin, IndentPositionYMax) + gameObject.transform.position.y;

        Instantiate(gameObjectForSpawn, new Vector3(positionX, positionY, 0), Quaternion.identity);

        if (IsLoop == true)
        {
            float timeRate = Random.Range(timeRateMin, timeRateMax);
            Invoke(nameof(CreateObject), timeRate);
        }
    }
}

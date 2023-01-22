using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float time;

    private void OnEnable()
    {
        Destroy(gameObject, time);
    }
}

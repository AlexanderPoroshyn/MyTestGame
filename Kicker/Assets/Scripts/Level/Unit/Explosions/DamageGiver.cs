using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    [SerializeField] private int damage;
    private RaycastHit2D raycastHit;

    [SerializeField] private CharacterType[] targetLayers;

    private void OnEnable()
    {
        for (int i = 0; i < targetLayers.Length; i++)
        {
            TryGiveDamage(targetLayers[i] + "");
        }
    }

    private void TryGiveDamage(string layerName)
    {
        raycastHit = Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask(layerName));

        if (raycastHit == true)
        {
            CharacterHealth characterHealth = raycastHit.collider.gameObject.GetComponent<CharacterHealth>();
            characterHealth.TakeDamage(damage);
            Destroy(this);
        }
    }

    private enum CharacterType
    {
        Ally,
        Obstacle,
        Enemy
    }
}

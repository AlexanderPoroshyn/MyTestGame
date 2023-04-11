using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAttackPattern : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private GameObject enemySelectedEffect;

    private void Start()
    {
        enemySelectedEffect.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        enemySelectedEffect.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        enemySelectedEffect.SetActive(false);
    }
}

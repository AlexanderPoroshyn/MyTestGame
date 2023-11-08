using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlaceSorter))]
public class AllyActionPoint : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    private PlaceSorter placeSorter => GetComponent<PlaceSorter>();
    private BoxCollider2D boxCollider => GetComponent<BoxCollider2D>();

    public event Action<Vector2> OnClicked;

    private void OnEnable()
    {
        UpdateState();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeSorter.CheckRequirements())
        {
            OnClicked?.Invoke(transform.position);
        }
    }

    private void UpdateState()
    {
        if (placeSorter.CheckRequirements())
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }
}

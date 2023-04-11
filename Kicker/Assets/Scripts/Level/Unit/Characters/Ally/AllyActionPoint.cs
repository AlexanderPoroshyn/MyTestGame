using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlaceSorter))]
public class AllyActionPoint : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    private PlaceSorter placeSorter => GetComponent<PlaceSorter>();

    public event Action<Vector2> OnClicked;

    private void OnEnable()
    {
        UpdateView();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeSorter.CheckRequirements())
        {
            OnClicked?.Invoke(transform.position);
        }
    }

    private void UpdateView()
    {
        if (placeSorter.CheckRequirements())
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}

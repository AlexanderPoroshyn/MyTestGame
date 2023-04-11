using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlaceSorter))]
public class SpawnCellAlly : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector2> OnClicked;

    private PlaceSorter placeSorter => GetComponent<PlaceSorter>();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeSorter.CheckRequirements())
        {
            OnClicked?.Invoke(transform.position);
        }
    }
}

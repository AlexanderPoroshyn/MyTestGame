using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlaceSorter))]
public class SpawnCellAlly : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector2> OnClicked;

    private PlaceSorter placeSorter => GetComponent<PlaceSorter>();
    [SerializeField] private GameObject blueSquare;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeSorter.CheckRequirements())
        {
            OnClicked?.Invoke(transform.position);
        }
    }

    public void UpdateView(bool isCardSelected)
    {
        if (isCardSelected == true && placeSorter.CheckRequirements())
        {
            blueSquare.SetActive(true);
        }
        else
        {
            blueSquare.SetActive(false);
        }
    }
}

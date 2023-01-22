using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllyActionButton : MonoBehaviour, IPointerClickHandler
{
    public event Action<AllyAction> OnClicked;
    [SerializeField] private AllyAction allyAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(allyAction);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AllyData ally;

    public event Action<Card> OnClicked;

    private Image image => GetComponent<Image>();
    private CardState state = CardState.Blocked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (state == CardState.Simple)
        {
            OnClicked?.Invoke(this);
        }
    }

    public void UpdateState(AllyData selectedAlly, int countMoney)
    {
        if (countMoney >= ally.price)
        {
            state = CardState.Simple;
            if (selectedAlly == ally)
            {
                state = CardState.Selected;
            }
        }
        else
        {
            state = CardState.Blocked;
        }
        UpdateView();
    }

    public AllyData GetAlly()
    {
        return ally;
    }

    private void UpdateView()
    {
        switch (state)
        {
            case CardState.Blocked:
                image.color = new Color(0.2f, 0.2f, 0.2f);
                break;
            case CardState.Selected:
                image.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case CardState.Simple:
                image.color = new Color(1f, 1f, 1f);
                break;
        }
    }

    private enum CardState
    {
        Blocked,
        Selected,
        Simple,
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AllyData ally;

    public event Action<Card> OnClicked;

    [SerializeField] private Image allySprite;
    [SerializeField] private Image background;
    [SerializeField] private Image superpower;

    [SerializeField] private Material simpleSprite, greySprite;

    [SerializeField] private Animator animator;

    [SerializeField] private Text price;
    [SerializeField] private Text health, damage;

    [SerializeField] private GameObject lightGradient;

    private CardState state = CardState.Blocked;

    private void Awake()
    {
        allySprite.sprite = ally.AllyBigSprite;
        background.sprite = ally.Background;

        superpower.sprite = ally.SuperpowerIcon;

        price.text = ally.Price + "";

        health.text = ally.Health + "";
        damage.text = ally.Damage + "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (state == CardState.Simple)
        {
            OnClicked?.Invoke(this);
        }
    }

    public void UpdateState(AllyData selectedAlly, int countMoney)
    {
        if (countMoney >= ally.Price)
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
                ChangeView(greySprite, "Deselected", false);
                break;
            case CardState.Selected:
                ChangeView(simpleSprite, "Selected", true);
                break;
            case CardState.Simple:
                ChangeView(simpleSprite, "Deselected", false);
                break;
        }
    }

    private void ChangeView(Material material, string animationName, bool isActiveLightGradient)
    {
        allySprite.material = material;
        background.material = material;

        animator.Play(animationName);

        lightGradient.SetActive(isActiveLightGradient);
    }

    private enum CardState
    {
        Blocked,
        Selected,
        Simple,
    }
}

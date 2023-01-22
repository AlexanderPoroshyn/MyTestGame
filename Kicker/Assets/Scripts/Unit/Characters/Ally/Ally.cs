using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ally : Character, IPointerClickHandler
{
    private bool isAction = false;
    private AllyAction allyAction;

    public event Action<Ally> OnClick;
    public event Action OnStartedAction;

    [SerializeField] private AllyActionButton[] allyActionButtons;

    private void Awake()
    {
        SubscribeEvents();
        for (int i = 0; i < allyActionButtons.Length; i++)
        {
            allyActionButtons[i].OnClicked += SelectedAction;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAction == false)
        {
            OnClick?.Invoke(this);
        }
    }

    public void Select()
    {
        CancelAllyAction();
        SetActiveActionButtons(true);
    }

    public void Deselect()
    {
        CancelAllyAction();
        SetActiveActionButtons(false);
    }

    private void CancelAllyAction()
    {
        if (allyAction != null)
        {
            allyAction.ProhibitAction();
        }
    }

    private void SelectedAction(AllyAction allyAction)
    {
        SetActiveActionButtons(false);
        allyAction.AllowAction();
        allyAction.OnStartedAction += StartAction;
        allyAction.OnFinishedAction += FinishAction;
        this.allyAction = allyAction;
    }

    private void StartAction()
    {
        isAction = true;
        OnStartedAction?.Invoke();
    }

    private void FinishAction()
    {
        allyAction.OnStartedAction -= StartAction;
        allyAction.OnFinishedAction -= FinishAction;
        isAction = false;
    }

    private void SetActiveActionButtons(bool active)
    {
        for (int i = 0; i < allyActionButtons.Length; i++)
        {
            allyActionButtons[i].gameObject.SetActive(active);
        }
    }

    protected override void Die()
    {
        StartEventOnDied(this);
    }
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterHealth))]
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
        StopShowPointsAction();
        SetActiveActionButtons(true);
    }

    public void Deselect()
    {
        StopShowPointsAction();
        SetActiveActionButtons(false);
    }

    private void StopShowPointsAction()
    {
        if (allyAction != null)
        {
            allyAction.ProhibitAction();
        }
    }

    private void SelectedAction(AllyAction allyAction)
    {
        if(this.allyAction != null)
        {
            DeselectedAction();
        }

        SetActiveActionButtons(false);
        allyAction.AllowAction();
        allyAction.OnStartedAction += StartAction;
        allyAction.OnFinishedAction += FinishAction;
        this.allyAction = allyAction;
    }

    private void DeselectedAction()
    {
        allyAction.OnStartedAction -= StartAction;
        allyAction.OnFinishedAction -= FinishAction;

        allyAction = null;
    }

    private void StartAction()
    {
        isAction = true;
        OnStartedAction?.Invoke();
    }

    private void FinishAction()
    {
        DeselectedAction();
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

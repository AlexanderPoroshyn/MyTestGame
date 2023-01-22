using UnityEngine;

[RequireComponent(typeof(AllySelector), typeof(Currency), typeof(AllyCreator))]
public class PlayerTurn : Turn
{
    private Currency currency => GetComponent<Currency>();
    private AllySelector allySelector => GetComponent<AllySelector>();
    private AllyCreator allyCreator => GetComponent<AllyCreator>();

    [SerializeField] private Bell bell;
    private bool isCanBellClicked;

    [SerializeField] private int bonusMoney;

    private void Awake()
    {
        bell.OnClicked += FinishedAction;
    }

    public override void StartTurn()
    {
        isCanBellClicked = true; 
        allySelector.StartSelecte();
        allyCreator.StartCreate();

        currency.AddMoney(0);
    }

    private void FinishedAction()
    {
        if (isCanBellClicked == true)
        {
            isCanBellClicked = false;
            allySelector.StopSelecte();
            allyCreator.StopCreate();

            currency.AddMoney(bonusMoney);

            StartEventFinishedTurn();
        }
    }
}

using System;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int money = 30;
    public event Action OnMoneyCountChenged;

    public void AddMoney(int countMoney)
    {
        money += countMoney;
        OnMoneyCountChenged?.Invoke();
    }

    public void RemoveMoney(int countMoney)
    {
        if(countMoney <= money)
        {
            money -= countMoney;
            OnMoneyCountChenged?.Invoke();
        }
    } 

    public int GetMoney()
    {
        return money;
    }
}

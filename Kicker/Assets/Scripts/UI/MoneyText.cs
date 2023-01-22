using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyText : MonoBehaviour
{
    private Text text => GetComponent<Text>();
    [SerializeField] private Currency currency;

    private void Awake()
    {
        currency.OnMoneyCountChenged += UpdateView;
    }

    private void UpdateView()
    {
        text.text = "Money: " + currency.GetMoney();
    }
}

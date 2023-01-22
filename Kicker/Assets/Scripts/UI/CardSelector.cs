using UnityEngine;

public class CardSelector : MonoBehaviour
{
    [SerializeField] private Currency currency;
    [SerializeField] private Card[] cards;
    private AllyData selectedAlly;

    private void Awake()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].OnClicked += SelectAlly;
        }
        currency.OnMoneyCountChenged += UpdateStateCards;
        UpdateStateCards();
    }

    private void SelectAlly(Card card)
    {
        selectedAlly = card.GetAlly();
        UpdateStateCards();
    }

    private void Deselect()
    {
        selectedAlly = null;
        UpdateStateCards();
    }

    private void UpdateStateCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].UpdateState(selectedAlly, currency.GetMoney());
        }
    }

    public AllyData GetAlly()
    {
        AllyData ally = selectedAlly;
        Deselect();

        return ally;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            string[] layerNames = new string[] { "SpawnCellAlly", "Card" };
            if (MousePositionInLayerCheker.CheckMousePosition(layerNames) != true)
            {
                Deselect();
            }
        }
    }
}

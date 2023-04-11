using UnityEngine;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    [SerializeField] private Currency currency;
    [SerializeField] private Card[] cards;
    private AllyData selectedAlly;

    private string[] layerNames = new string[] { "SpawnCellAlly", "Card" };

    [SerializeField] private Image patternMove, patternAttack;
    [SerializeField] private Sprite simpleSpritePatternMove, simpleSpritePatternAttack;

    [SerializeField] private GameObject cardDimming;

    private bool isCardSelectorOn;

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
        if (isCardSelectorOn == true)
        {
            selectedAlly = card.GetAlly();
            UpdateStateCards();
        }
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

        if (selectedAlly != null)
        {
            patternMove.sprite = selectedAlly.PatternMove;
            patternAttack.sprite = selectedAlly.PatternAttack;
        }
        else
        {
            patternMove.sprite = simpleSpritePatternMove;
            patternAttack.sprite = simpleSpritePatternAttack;
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
            if (MousePositionInLayerCheker.CheckMousePosition(layerNames) == false)
            {
                Deselect();
            }
        }
    }

    public void CardSelectorOn()
    {
        isCardSelectorOn = true;
        cardDimming.SetActive(false);
    }

    public void CardSelectorOff()
    {
        isCardSelectorOn = false;
        cardDimming.SetActive(true);
        Deselect();
    }
}

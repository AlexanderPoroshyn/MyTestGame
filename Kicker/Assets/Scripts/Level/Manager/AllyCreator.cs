using UnityEngine;

[RequireComponent(typeof(AccumulationAllies), typeof(Currency))]
public class AllyCreator : MonoBehaviour
{
    private AccumulationAllies accumulationAllies => GetComponent<AccumulationAllies>();
    private Currency currency => GetComponent<Currency>();

    private bool isCanCreate;

    [SerializeField] private SpawnCellAlly[] spawnCells;
    [SerializeField] private CardSelector cardSelector;
    private AllyData allyData;

    private void Awake()
    {
        for (int i = 0; i < spawnCells.Length; i++)
        {
            spawnCells[i].OnClicked += CreateAlly;
        }    
    }

    private void CreateAlly(Vector2 position)
    {
        allyData = cardSelector.GetAlly();

        if (isCanCreate == true && allyData != null)
        {
            if (allyData.Price <= currency.GetMoney())
            {
                currency.RemoveMoney(allyData.Price);
                Ally createdAlly = Instantiate(allyData.Ally, position, Quaternion.identity);

                accumulationAllies.AddCharacter(createdAlly);
            }
        }
    }

    public void StartCreate()
    {
        isCanCreate = true;
    }

    public void StopCreate()
    {
        isCanCreate = false;
        allyData = cardSelector.GetAlly();
    }
}

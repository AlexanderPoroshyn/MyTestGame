using UnityEngine;

[RequireComponent(typeof(AccumulationEnemies))]
public class WinnerChecker : MonoBehaviour
{
    private AccumulationEnemies accumulationEnemies => GetComponent<AccumulationEnemies>();
    [SerializeField] private DefeatLine[] defeatLines;

    public Winner CheckWinners()
    {
        if (CheckPlayerWin() == true)
        {
            return Winner.Player;
        }
        if (CheckComputerWin() == true)
        {
            return Winner.Computer;
        }
        return Winner.None;
    }

    private bool CheckPlayerWin()
    {
        int countEnemies = accumulationEnemies.GetEnemies().Count;
        if (countEnemies == 0)
        {
            return true;
        }
        return false;
    }

    private bool CheckComputerWin()
    {
        for (int i = 0; i < defeatLines.Length; i++)
        {
            if (defeatLines[i].CheckEnemies() == true)
            {
                return true;
            }
        }
        return false;
    }

    public enum Winner
    {
        Player,
        Computer,
        None
    }
}

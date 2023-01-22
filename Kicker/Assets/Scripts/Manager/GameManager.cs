using UnityEngine;

[RequireComponent(typeof(PlayerTurn), typeof(ComputerTurn))]
public class GameManager : MonoBehaviour
{
    private Turn playerTurn => GetComponent<PlayerTurn>();
    private Turn computerTurn => GetComponent<ComputerTurn>();
    //private GameState gameState = GameState.LoadMap;

    private void Awake()
    {
        playerTurn.OnFinishedTurn += StartComputerTurn;
        computerTurn.OnFinishedTurn += StartPlayerTurn;
    }

    private void Start()
    {
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        //gameState = GameState.PlayerTurn;
        playerTurn.StartTurn();
    }

    private void StartComputerTurn()
    {

        //gameState = GameState.ComputerTurn;
        computerTurn.StartTurn();

    }

    private enum GameState
    {
        LoadMap,
        PlayerTurn,
        ComputerTurn,
        Finish
    }
}

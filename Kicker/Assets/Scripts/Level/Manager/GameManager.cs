using UnityEngine;

[RequireComponent(typeof(PlayerTurn), typeof(ComputerTurn), typeof(LevelExitController))]
public class GameManager : MonoBehaviour
{
    private Turn playerTurn => GetComponent<PlayerTurn>();
    private Turn computerTurn => GetComponent<ComputerTurn>();
    private LevelExitController levelExit => GetComponent<LevelExitController>();
    private WinnerChecker winnerChecker => GetComponent<WinnerChecker>();
    private WinnerChecker.Winner winner;

    private GameState gameState = GameState.PlayerTurn;

    [SerializeField] private PlayerTryExitLevelHandler playerTryExitLevelHandler;

    private void Awake()
    {
        playerTurn.OnFinishedTurn += StartComputerTurn;
        computerTurn.OnFinishedTurn += CheckWinner;

        playerTryExitLevelHandler.OnDoneExit += TryExitLevel;
    }

    private void Start()
    {
        StartPlayerTurn();
    }

    private void CheckWinner()
    {
        winner = winnerChecker.CheckWinners();
        if (winner == WinnerChecker.Winner.None)
        {
            StartPlayerTurn();
        }
        else if (winner == WinnerChecker.Winner.Player)
        {
            PlayerWin();
        }
        else
        {
            ComputerWin();
        }
    }

    private void StartPlayerTurn()
    {
        if (gameState != GameState.Ending && gameState != GameState.LoadMap)
        {
            gameState = GameState.PlayerTurn;
            playerTurn.StartTurn();
        }
    }

    private void StartComputerTurn()
    {
        if (gameState != GameState.Ending && gameState != GameState.LoadMap)
        {
            gameState = GameState.ComputerTurn;
            computerTurn.StartTurn();
        }
    }

    private void PlayerWin()
    {
        StopLevel();
        levelExit.ExitLevelVictory();
    }

    private void ComputerWin()
    {
        StopLevel();
        levelExit.ExitLevelDefeat();
    }

    private void TryExitLevel()
    {
        if (gameState != GameState.Ending)
        {
            StopLevel();

            levelExit.ExitLevelSimple();
        }
    }

    private void StopLevel()
    {
        gameState = GameState.Ending;
        playerTurn.StopWork();
        computerTurn.StopWork();
    }

    private enum GameState
    {
        LoadMap,
        PlayerTurn,
        ComputerTurn,
        Ending
    }
}

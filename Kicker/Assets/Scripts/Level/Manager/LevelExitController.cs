using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitController : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;

    public void ExitLevelSimple()
    {
        Invoke(nameof(ActivateBlackScreen), 0f);
        Invoke(nameof(ExitScene), 2f);
    }

    public void ExitLevelDefeat()
    {
        Invoke(nameof(ActivateBlackScreen), 1.5f);
        Invoke(nameof(ExitScene), 4f);
    }

    public void ExitLevelVictory()
    {
        Invoke(nameof(ActivateBlackScreen), 3f);
        Invoke(nameof(ExitScene), 5f);
    }

    private void ActivateBlackScreen()
    {
        blackScreen.gameObject.SetActive(true);
    }

    private void ExitScene()
    {
        SceneManager.LoadScene("MapMenu");
    }
}

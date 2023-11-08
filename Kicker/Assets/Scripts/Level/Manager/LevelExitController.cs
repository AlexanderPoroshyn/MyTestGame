using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitController : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;

    [SerializeField] private Animator victoryEffect;
    [SerializeField] private Animator defeatEffect;

    public void ExitLevelSimple()
    {
        Invoke(nameof(ActivateBlackScreen), 0f);
        Invoke(nameof(ExitScene), 2f);
    }

    public void ExitLevelDefeat()
    {
        defeatEffect.Play("Defeat");
        Invoke(nameof(ActivateBlackScreen), 3f);
        Invoke(nameof(ExitScene), 4f);
    }

    public void ExitLevelVictory()
    {
        victoryEffect.Play("Victory");
        Invoke(nameof(ActivateBlackScreen), 3f);
        Invoke(nameof(ExitScene), 4f);
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

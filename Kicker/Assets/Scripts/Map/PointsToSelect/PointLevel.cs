using UnityEngine;
using UnityEngine.SceneManagement;

public class PointLevel : MapPointForSelect
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject blackScreen;

    public override void Activate()
    {
        blackScreen.SetActive(true);
        Invoke(nameof(LoadScene), 2f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

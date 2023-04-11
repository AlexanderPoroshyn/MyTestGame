using UnityEngine;
using UnityEngine.SceneManagement;

public class PointLevel : MapPointForSelect
{
    [SerializeField] private string sceneName;

    public override void Activate()
    {
        SceneManager.LoadScene(sceneName);
    }
}

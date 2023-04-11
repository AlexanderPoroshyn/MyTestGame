using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthText : MonoBehaviour
{
    private Text text => GetComponent<Text>();
    [SerializeField] private CharacterHealth characterHealth;

    private void Awake()
    {
        characterHealth.OnChangedHealth += UpdateView;
    }

    private void UpdateView(int countHealth)
    {
        text.text = "" + countHealth;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CountStepsText : MonoBehaviour
{
    private Text text => GetComponent<Text>();
    [SerializeField] private AllySelector allySelector;

    private void Awake()
    {
        UpdateView(allySelector.GetCountSteps());
        allySelector.OnStepsCountChanged += UpdateView;
    }

    private void UpdateView(int countSteps)
    {
        text.text = "Steps: " + countSteps;
    }
}

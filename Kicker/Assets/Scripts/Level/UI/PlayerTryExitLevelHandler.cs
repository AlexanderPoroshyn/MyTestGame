using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTryExitLevelHandler : MonoBehaviour
{
    private float exitTime = 0f;
    private float finalTime = 3f;
    private float timeSpeed = 3.5f;

    private bool isButtonDown;

    [SerializeField] private Text text;
    private float textColorA = 0f;
    private float fadeSpeed = 3f;

    [SerializeField] private Image imageCircle;

    public event Action OnDoneExit;
    private bool isDoneExit = false;

    private void Update()
    {
        if (isDoneExit == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                exitTime = Mathf.MoveTowards(exitTime, finalTime, timeSpeed * Time.deltaTime);
                isButtonDown = true;
            }
            else
            {
                exitTime = Mathf.MoveTowards(exitTime, 0f, 2f * timeSpeed * Time.deltaTime);
                isButtonDown = false;
            }
            if (exitTime == finalTime)
            {
                OnDoneExit?.Invoke();
                isDoneExit = true;
            }
        }
        UpdateView();
    }

    private void UpdateView()
    {
        if (isButtonDown == true && isDoneExit == false)
        {
            textColorA = 1f;
        }
        if (isButtonDown == false && isDoneExit == false)
        {
            textColorA = Mathf.MoveTowards(textColorA, 0f, fadeSpeed * Time.deltaTime);
        }

        if (isDoneExit == false)
        {
            imageCircle.fillAmount = exitTime / finalTime;
            text.color = new Color(1f, 1f, 1f, textColorA);
        }

        if (isDoneExit == true)
        {
            imageCircle.fillAmount = 1f;
            text.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}

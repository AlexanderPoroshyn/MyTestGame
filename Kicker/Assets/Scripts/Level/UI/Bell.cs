using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Bell : MonoBehaviour, IPointerClickHandler
{
    public event Action OnClicked;

    private Animator animator => GetComponent<Animator>();

    private Coroutine playAnimationIdle;

    private Image image => GetComponent<Image>();
    [SerializeField] private ParticleSystem sparkEffect;
    [SerializeField] private Material normalMaterial, greyMaterial;

    private bool isBellOn;

    private void Start()
    {
        playAnimationIdle = StartCoroutine(PlayAnimationIdle());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isBellOn == true)
        {
            OnClicked?.Invoke();
            StopCoroutine(playAnimationIdle);
            PlayAnimationClicked();
            sparkEffect.Play();
        }
    }

    private void PlayAnimationClicked()
    {
        animator.Play("Clicked", 0, 0);
        playAnimationIdle = StartCoroutine(PlayAnimationIdle());
    }

    private IEnumerator PlayAnimationIdle()
    {
        yield return new WaitForSeconds(1f);

        animator.Play("Idle");
    }

    public void BellOn()
    {
        isBellOn = true;
        image.material = normalMaterial;
        image.color = new Color(1f, 1f, 1f);
    }

    public void BellOff()
    {
        isBellOn = false;
        image.material = greyMaterial;
        image.color = new Color(0.7f, 0.7f, 0.7f);
    }
}

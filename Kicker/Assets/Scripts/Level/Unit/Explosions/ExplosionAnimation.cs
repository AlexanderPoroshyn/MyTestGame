using UnityEngine;
using System.Collections;

public class ExplosionAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] animationSprites;
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    private void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        for (int i = 0; i < animationSprites.Length; i++)
        {
            spriteRenderer.sprite = animationSprites[i];

            yield return new WaitForSeconds(0.05f);
        }
    }
}

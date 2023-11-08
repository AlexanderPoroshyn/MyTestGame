using UnityEngine;
using System.Collections;

public class ExplosionView : MonoBehaviour
{
    [SerializeField] private Sprite[] animationSprites;
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    private int chanceFlipX, chanceFlipY;

    private void Start()
    {
        chanceFlipX = Random.Range(0, 2);
        chanceFlipY = Random.Range(0, 2);

        if (chanceFlipX == 1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (chanceFlipY == 1)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }

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

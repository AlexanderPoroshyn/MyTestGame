using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CharacterHealth))]
public class Obstacle : Character
{
    private int health;
    private int spriteNumber;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    private void Start()
    {
        SubscribeEvents();

        health = Random.Range(1, 7);
        spriteNumber = Random.Range(0, sprites.Length);

        characterHealth.SetHealth(health);
        spriteRenderer.sprite = sprites[spriteNumber];
    }

    protected override void Die()
    {
        StartEventOnDied(this);
    }
}


using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CharacterHealth))]
public class Obstacle : Character
{
    private int health;
    private int spriteNumber;
    private int chanceTurn;
    [SerializeField] private int minHealth, maxHealth;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    private void Start()
    {
        SubscribeEvents();

        health = Random.Range(minHealth, maxHealth + 1);
        characterHealth.SetHealth(health);

        SetView();
    }

    private void SetView()
    {
        spriteNumber = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[spriteNumber];

        chanceTurn = Random.Range(0, 2);
        if(chanceTurn == 1)  
        {
            spriteRenderer.flipX = true;
        }
    }

    protected override void Die()
    {
        StartEventOnDied(this);
    }
}


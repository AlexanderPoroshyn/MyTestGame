using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public event Action OnDied;
    public event Action<int> OnChangedHealth;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDied?.Invoke();
        }
        OnChangedHealth?.Invoke(health);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        OnChangedHealth?.Invoke(health);
    }
}

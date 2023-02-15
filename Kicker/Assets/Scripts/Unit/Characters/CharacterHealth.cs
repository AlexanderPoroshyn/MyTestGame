using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public event Action OnDied;
    public event Action<int> OnChangedHealth;

    private void Start()
    {
        OnChangedHealth?.Invoke(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDied?.Invoke();
        }
        OnChangedHealth?.Invoke(health);
    }
}

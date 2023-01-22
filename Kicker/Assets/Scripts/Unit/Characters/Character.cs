using System;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
public abstract class Character : MonoBehaviour
{
    public event Action<Character> OnDied;
    protected CharacterHealth characterHealth => GetComponent<CharacterHealth>();

    protected void SubscribeEvents()
    {
        characterHealth.OnDied += Die;
    }

    protected abstract void Die();

    protected void StartEventOnDied(Character character)
    {
        OnDied?.Invoke(character);
        Destroy(gameObject);
    }
}

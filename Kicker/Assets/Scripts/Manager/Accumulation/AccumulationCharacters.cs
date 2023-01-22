using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class AccumulationCharacters : MonoBehaviour
{
    private List<Character> characters = new List<Character>();
    public event Action OnChangentCountCharacters;

    protected List<Character> GetCharacters()
    {
        return characters;
    }

    public void AddCharacter(Character character)
    {
        characters.Add(character);
        character.OnDied += RemoveCharacter;
        OnChangentCountCharacters?.Invoke();
    }

    private void RemoveCharacter(Character character)
    {
        characters.Remove(character);
        character.OnDied -= RemoveCharacter;
        OnChangentCountCharacters?.Invoke();
    }
}

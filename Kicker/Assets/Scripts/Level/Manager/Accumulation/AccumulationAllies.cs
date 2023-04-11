using System.Collections.Generic;

public class AccumulationAllies : AccumulationCharacters
{
    public List<Ally> GetAllies()
    {
        List<Ally> allies = new List<Ally>();
        List<Character> characters = GetCharacters();

        for (int i = 0; i < characters.Count; i++)
        {
            allies.Add((Ally)characters[i]);
        }
        return allies;
    }
}

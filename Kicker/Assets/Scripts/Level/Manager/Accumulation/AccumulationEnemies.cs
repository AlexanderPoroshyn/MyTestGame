using System.Collections.Generic;

public class AccumulationEnemies : AccumulationCharacters
{
    public List<Enemy> GetEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();
        List<Character> characters = GetCharacters();

        for (int i = 0; i < characters.Count; i++)
        {
            enemies.Add((Enemy)characters[i]);
        }
        return enemies;
    }
}

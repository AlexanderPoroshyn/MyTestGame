using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AccumulationEnemies))]
public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private int creationStepCount;
    private int creationStartStepCount, enemiesOpeningRate; 
    [SerializeField] private SpawnCellEnemy[] spawnCells;

    private int minCreateEnemies = 1;
    [SerializeField] private int maxCreateEnemies = 3;

    private int countCreateEnemies;
    private SpawnCellEnemy selectedSpawnCell;

    [SerializeField] private Enemy[] enemies;
    private List<SpawnCellEnemy> freeSpawnCells = new List<SpawnCellEnemy>();
    private List<Enemy> openedEnemies;

    private AccumulationEnemies accumulationEnemies => GetComponent<AccumulationEnemies>();

    private void Awake()
    {
        creationStartStepCount = creationStepCount;
        enemiesOpeningRate = creationStartStepCount / enemies.Length;
    }

    public void DoAction()
    {
        if (creationStepCount > 0)
        {
            if (creationStepCount <= maxCreateEnemies)
            {
                countCreateEnemies = creationStepCount;
            }
            else
            {
                countCreateEnemies = Random.Range(minCreateEnemies, maxCreateEnemies + 1);
            }
            for (int i = 0; i < countCreateEnemies; i++)
            {
                CreateEnemies();
            }
        }
    }

    private void CreateEnemies()
    {
        selectedSpawnCell = GetRandomCell();
        if (selectedSpawnCell != null)
        {
            Enemy enemy = GetRandomEnemy();
            Enemy createdEnemy = Instantiate(enemy, selectedSpawnCell.transform.position, Quaternion.identity);
            accumulationEnemies.AddCharacter(createdEnemy);

            creationStepCount -= 1;
        }
    }

    private Enemy GetRandomEnemy()
    {
        int doneCreationSteps = creationStartStepCount - creationStepCount;
        openedEnemies = new List<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            if(i * enemiesOpeningRate <= doneCreationSteps)
            {
                openedEnemies.Add(enemies[i]);
            }
        }
        int numberRandomEnemy = Random.Range(0, openedEnemies.Count);
        return openedEnemies[numberRandomEnemy];
    }

    private SpawnCellEnemy GetRandomCell()
    {
        freeSpawnCells = new List<SpawnCellEnemy>();

        for (int i = 0; i < spawnCells.Length; i++)
        {
            if(spawnCells[i].IsCanSpawn("Enemy") == true)
            {
                freeSpawnCells.Add(spawnCells[i]);
            }
        }

        if(freeSpawnCells.Count != 0)
        {
            int randomSpawnCell = Random.Range(0, freeSpawnCells.Count);
            return freeSpawnCells[randomSpawnCell];
        }
        return null;
    }
}

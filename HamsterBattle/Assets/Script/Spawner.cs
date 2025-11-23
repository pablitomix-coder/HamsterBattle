using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnPoint;
    public bool isPlayerSpawner;

    
    public void SpawnUnit()
    {
        GameObject newUnit = Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
        var unit = newUnit.GetComponent<Unit>();
        unit.isPlayerUnit = isPlayerSpawner;
        newUnit.tag = isPlayerSpawner ? "PlayerUnit" : "EnemyUnit";
    }
}

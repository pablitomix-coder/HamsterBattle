
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Spawner spawner;
    public float spawnInterval = 4f;
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            spawner.SpawnUnit();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

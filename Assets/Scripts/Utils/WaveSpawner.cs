using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public WavesScriptableData WaveStats;

    public int WaveCount;

    public float SpawnRate, TimeBetweenWaves;

    bool startNextWave;

    void Start()
    {
        WaveCount = WaveStats.waveCount;
        SpawnRate = WaveStats.spawnRate;
        TimeBetweenWaves = WaveStats.timeBetweenWaves;
    }

    void Update()
    {
        if (startNextWave)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        startNextWave = false;

        // for (int i = 0; i < enemyCount; i++)
        // {
        //     GameObject enemyClone = Instantiate(enemy);

        //     yield return new WaitForSeconds(spawnRate);
        // }

        // spawnRate -= 0.1f;
        // enemyCount += 3;
        // waveCount += 1;

        // yield return new WaitForSeconds(timeBetweenWaves);

        // waveIsDone = true;

        yield return null;
    }
}
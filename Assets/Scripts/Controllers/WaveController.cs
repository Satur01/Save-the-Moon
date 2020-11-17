using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WavesScriptableData WaveStats;

    int waveCount;
    float spawnRate, timeBetweenWaves;
    bool startNextWave;

    void Start()
    {
        waveCount = WaveStats.waveCount;
        spawnRate = WaveStats.spawnRate;
        timeBetweenWaves = WaveStats.timeBetweenWaves;
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
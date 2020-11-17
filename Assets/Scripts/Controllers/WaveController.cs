using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WavesScriptableData WaveStats;

    float timeBetweenWaves;
    bool startNextWave;

    void Start()
    {
        timeBetweenWaves = WaveStats.timeBetweenWaves;
        startNextWave = true;
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
        // GameObject enemyClone;

        for (int i = 0; i < WaveStats.waves[0].enemies.Length; i++)
        {
            Instantiate(WaveStats.waves[0].enemies[i], new Vector2(0,6f), transform.rotation);
            yield return new WaitForSeconds(WaveStats.waves[0].spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWaves);

        startNextWave = true;

        yield return null;
    }
}
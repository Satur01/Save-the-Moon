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

        float offset = 0;

        for (int i = 0; i < WaveStats.waves[0].enemies.Length; i++)
        {
            GameObject tmp = Instantiate(WaveStats.waves[0].enemies[i], transform.position, transform.rotation);

            tmp.transform.SetParent(this.transform);

            offset += i > 0 ? WaveStats.waves[0].offsetBetweenEnemies + WaveStats.waves[0].offsetMultiplier : WaveStats.waves[0].offsetBetweenEnemies;

            tmp.GetComponent<Enemy>().offset = offset;

            yield return new WaitForSeconds(WaveStats.waves[0].spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWaves);

        startNextWave = true;

        yield return null;
    }
}
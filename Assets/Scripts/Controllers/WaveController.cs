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

        foreach (Wave wave in WaveStats.waves)
        {
            float offset = 0;

            for (int waveIndex = 0; waveIndex < wave.enemies.Length; waveIndex++)
            {
                GameObject tmp = InstantiateEnemy(wave, ref offset, waveIndex);
                EnemySetup(wave, offset, tmp);

                yield return new WaitForSeconds(wave.spawnRate);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }

        yield return null;
    }

    private static void EnemySetup(Wave wave, float offset, GameObject tmp)
    {
        Enemy enemyRef = tmp.GetComponent<Enemy>();
        enemyRef.offset = offset;
        enemyRef.typeOfWave = wave.typeOfWave;
    }

    private GameObject InstantiateEnemy(Wave wave, ref float offset, int waveIndex)
    {
        GameObject tmp = Instantiate(wave.enemies[waveIndex], transform.position, transform.rotation);
        tmp.transform.SetParent(this.transform);
        offset += waveIndex > 0 ? wave.offsetBetweenEnemies + wave.offsetMultiplier : wave.offsetBetweenEnemies;
        return tmp;
    }
}
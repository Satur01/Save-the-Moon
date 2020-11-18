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

            for(int i = 0; i < wave.enemies.Length; i++)
            {
                GameObject tmp = Instantiate(wave.enemies[i], transform.position, transform.rotation);
                tmp.transform.SetParent(this.transform);
                offset += i > 0 ? wave.offsetBetweenEnemies + wave.offsetMultiplier : wave.offsetBetweenEnemies;
                tmp.GetComponent<Enemy>().offset = offset;
                yield return new WaitForSeconds(WaveStats.waves[0].spawnRate);
            }   

            yield return new WaitForSeconds(timeBetweenWaves);       
        }       

        yield return null;
    }
}
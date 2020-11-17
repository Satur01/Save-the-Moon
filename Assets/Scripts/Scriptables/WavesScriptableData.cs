using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObjects/Wave")]
public class WavesScriptableData : ScriptableObject
{
    public int waveCount, timeBetweenWaves;
    public float spawnRate;

    public Wave.WaveType[] typeOfWave;
    public List<EnemyScriptableData> enemiesData;
}

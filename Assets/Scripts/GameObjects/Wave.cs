
using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Wave
{
    public enum WaveType
    {
        Pattern,
        Stationary
    }

    public WaveType typeOfWave;
    public float spawnRate;
    public GameObject[] enemies;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObjects/Wave")]
public class WavesScriptableData : ScriptableObject
{
    [Header("Wave General Settings")]
    public float timeBetweenWaves;

    [Header("Wave's Enemies Settings")]
    public Wave[] waves;
}

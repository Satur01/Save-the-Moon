using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboLevels
{
    D, C, B, A, S
}

[Serializable]
public class ComboLevel
{
    public ComboLevels level;
    public int timeLimit;
    public float comboMultiplier;
}

[CreateAssetMenu(fileName = "Combo Settings", menuName = "ScriptableObjects/Settings")]
public class ComboLevelsScriptable : ScriptableObject
{
    [Header("Combo Settings")]
    public ComboLevel[] levelSettings;
}


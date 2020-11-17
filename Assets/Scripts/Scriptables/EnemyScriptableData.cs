using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableData : ScriptableObject
{
    [Header("Enemy Basic Settings")]
    public int life;
    public int damage;
    public int movementSpeed;
    public float shootRate;
}

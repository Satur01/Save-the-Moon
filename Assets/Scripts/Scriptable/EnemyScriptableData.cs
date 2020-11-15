using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableData")]
public class EnemyScriptableData : ScriptableObject
{
    int life;
    int damage;
    int movementSpeed;
    float shootRate;
    Sprite enemySprite;
}

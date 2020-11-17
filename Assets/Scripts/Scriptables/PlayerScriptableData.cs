using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerScriptableData : ScriptableObject
{
    int life;
    int damage;
    int movementSpeed;
    float shootRate;
    Sprite playerSprite;
}

using UnityEngine;
using static UnityEngine.Mathf;

public static class PatternsLibrary
{
    public static float SinPattern (float timeMultiplier, float amplitude = 1) 
    {
        return amplitude * Sin(Time.deltaTime * timeMultiplier);
    }
}

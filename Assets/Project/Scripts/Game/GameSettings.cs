using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Hedgehog/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Force")]
    //Can using a Vector2
    [Range(0, 100)]
    public float clickMinForce = 100;
    [Range(100, 1000)]
    public float clickMaxForce = 500;

    [Header("Spawn")]
    //Can using a Vector2
    [Range(0.1f, 1f)]
    public float spawnMinSize = 0.1f;
    [Range(1f, 5f)]
    public float spawnMaxSize = 1.0f;

    [Header("Game")]
    public bool infinitySpawnOnMouseDown = false;
    public GameObject objectToSpawn;

}

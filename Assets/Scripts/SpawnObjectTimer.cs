using UnityEngine;
using System.Collections;
public class SpawnObjectTimer : MonoBehaviour
{
    public float spawnTime = 5.0f;
    void Start()
    {
        Invoke("DoSpawn", spawnTime);
    }
    void DoSpawn()
    {
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
    }
}
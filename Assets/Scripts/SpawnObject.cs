using UnityEngine;
using System.Collections;
public class SpawnObject : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform enemySpawn;
    public void Spawn()
    {
        Instantiate(objectPrefab, enemySpawn.position, enemySpawn.rotation);
    }
}

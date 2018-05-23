using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {
    public int health = 100;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z + adjustExplosionAngle);
            Instantiate(explosionPrefab, transform.position, newRot);
            GetComponent<AddScore>().DoSendScore();

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

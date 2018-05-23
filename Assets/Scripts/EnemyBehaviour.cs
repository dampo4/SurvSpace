using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health = 10;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;
    private Transform player;
    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;
            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget2D>().target = player;
        }
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
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }
}
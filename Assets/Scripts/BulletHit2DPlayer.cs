using UnityEngine;
using System.Collections;
public class BulletHit2DPlayer : MonoBehaviour
{
    public static float damage = 10;
    public string damageTag = "";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        
    }
}
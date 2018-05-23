using UnityEngine;
using System.Collections;
public class BulletHit2DEnemy : MonoBehaviour
{
    public static float damage = 10;
    public string damageTag = "";
    public static int reduction = 0;

    void Start()
    {
        if(Time.timeSinceLevelLoad < 0.00001)
        {
            reduction = 0;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        damage = 10;
        if (other.CompareTag(damageTag))
        {
            damage = ((damage * ((Mathf.Round(Time.timeSinceLevelLoad / 60f)) + 1)) * (Mathf.Pow(0.75f, reduction)));
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        
    }
}
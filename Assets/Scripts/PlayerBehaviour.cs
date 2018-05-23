using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    public delegate void UpdateHealth(float newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public static float health = 1000;
    private Animator gunAnim;
    void Start()
    {
        SendHealthData();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isFiring", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
        
    }
    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
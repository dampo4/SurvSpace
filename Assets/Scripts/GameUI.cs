using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    public static float health;
    public static int score;
    private string gameInfo = "";
    private float seconds, minutes;
    public Canvas Menu;
    private Rect boxRect = new Rect(10, 10, 300, 50);
    GameObject[] pauseObjects;
    void Start()
    {
        PlayerBehaviour.health = 1000;
        score = 0;
        UpdateUI();
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Menu.GetComponent<Canvas>().enabled = true;

            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Menu.GetComponent<Canvas>().enabled = false;
            }
        }
    }
    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }
    void HandleonUpdateHealth(float newHealth)
    {
        health = newHealth;
        UpdateUI();
    }
    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
    void UpdateUI()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + PlayerBehaviour.health.ToString() + "\nTime: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}

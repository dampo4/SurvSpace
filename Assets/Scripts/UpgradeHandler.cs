using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour {

    public Button damage, health, reduction;
    public GameObject prefab;
    private bool isBought = false;
	// Use this for initialization
	void Start () {
        damage.onClick.AddListener(DoubleDamage);
        health.onClick.AddListener(RestoreHealth);
        reduction.onClick.AddListener(ReduceDamage);
	}
	void DoubleDamage()
    {
        if(GameUI.score >= 200 && isBought == false)
        {
            isBought = true;
            GameUI.score -= 200;
            BulletHit2DPlayer.damage = BulletHit2DPlayer.damage * 2;
        }
    }
    void RestoreHealth()
    {
        if(GameUI.score >= 200)
        {
            GameUI.score -= 200;
            PlayerBehaviour.health = 1000;
            
        }
    }
    void ReduceDamage()
    {
        if(GameUI.score >= 200)
        {
            GameUI.score -= 200;
            BulletHit2DEnemy.reduction += 1;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}

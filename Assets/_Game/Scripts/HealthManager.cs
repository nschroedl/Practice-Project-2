using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static int playerHealth;
    public int maxPlayerHealth;
    public bool isDead;
    private LevelManager levelManager;

    Text text;

    // Use this for initialization
    void Start () {

        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        isDead = false;
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();           
            isDead = true;            
        }
        text.text = "" + playerHealth;    
	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;    
    }

    public void FullHealth()
    {
        isDead = false;
        playerHealth = maxPlayerHealth;
    }
}

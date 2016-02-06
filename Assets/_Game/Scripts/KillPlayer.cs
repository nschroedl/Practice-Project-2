using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    private PlayerController player;
    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.name == "Player" && player.isAlive)
        {            
            levelManager.RespawnPlayer();
        }
    }


}

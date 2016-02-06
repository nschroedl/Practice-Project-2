using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;
    private PlayerController player;

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && player.isAlive)
        {
            HealthManager.HurtPlayer(damageToGive);
            GetComponent<AudioSource>().Play();
           
            player.knockbackCount = player.knockbackLength;

            if(other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            } else
            {
                player.knockFromRight = false;
            }
        }
    }
}

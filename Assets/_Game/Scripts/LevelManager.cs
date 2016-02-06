using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticles;
    public GameObject respawnParticles;

    public float respawnDelay;
    public int pointPenaltyOnDeath;
    private float gravityStore;

    private CameraController camera;
    private LifeManager lifeSystem;
    public HealthManager healthManager;

	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    //
    public IEnumerator RespawnPlayerCo()
    {
        lifeSystem.TakeLife();

        if (lifeSystem.GetLifeCounter() > 0)
        {
            player.isAlive = false;
            Instantiate(deathParticles, player.transform.position, player.transform.rotation);
            player.enabled = false;
            player.GetComponent<Renderer>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            camera.isFollowing = false;
            gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            ScoreManager.AddPoints(-pointPenaltyOnDeath);
            yield return new WaitForSeconds(respawnDelay);
            player.transform.position = currentCheckpoint.transform.position;
            player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
            player.knockbackCount = 0;
            player.isAlive = true;
            healthManager.FullHealth();
            player.enabled = true;
            player.GetComponent<Renderer>().enabled = true;
            camera.isFollowing = true;
            Instantiate(respawnParticles, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        }
    }
}

using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;
    public GameObject coinPickupParticles;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
        {
            return;
        }

        Instantiate(coinPickupParticles, gameObject.transform.position, gameObject.transform.rotation);
        ScoreManager.AddPoints(pointsToAdd);        
        Destroy(gameObject);

    }
}

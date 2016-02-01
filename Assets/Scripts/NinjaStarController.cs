﻿using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    //public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    //public int pointsForKill;
    public float rotationSpeed;
    public int damageToGive;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().angularVelocity = -rotationSpeed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //ScoreManager.AddPoints(pointsForKill);
            //Destroy(other.gameObject);

            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

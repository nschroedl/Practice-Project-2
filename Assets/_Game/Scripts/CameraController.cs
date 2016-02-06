using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public PlayerController player;

    public bool isFollowing;

    public float xOffset;
    public float yOffset;
    public GameObject cube;
    public float gameTimer;

	// Use this for initialization
	void Start () {
        cube = GameObject.Find("Cube");
        player = FindObjectOfType<PlayerController>();
        isFollowing = true;
        gameTimer = 30;
       // xPos = cube.transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {

//        if (gameTimer > 0)
 //       {
 //           gameTimer += -Time.deltaTime;
 //           ProgressBar(gameTimer);
 //       }

        if (isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        } 
	}
    /*
        public float maxCount;
        public float currentCount;
        public float maxScale;
        public float xPos;
        public float yPos;


        void ProgressBar(float currentCount)
        {
            if(currentCount <= maxCount && currentCount > 0) { 
                float percent = (currentCount / maxCount);
                float size = maxScale * percent;
                cube.transform.localScale = new Vector3(size, cube.transform.localScale.y, cube.transform.localScale.z);
                cube.transform.position = new Vector3(xPos + ((maxScale - size)/2), cube.transform.position.y, cube.transform.position.z);
            }
        }
        */
}

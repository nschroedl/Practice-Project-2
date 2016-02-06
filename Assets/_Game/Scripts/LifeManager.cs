using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {


    public int startingLives;
    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    public string mainMenu;

    public float waitAfterGameOver;

    // Use this for initialization
    void Start () {
        theText = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
        lifeCounter = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
        theText.text = "x " + lifeCounter;

        if(lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }
	}

    public void GiveLife()
    {
        lifeCounter ++;

    }

    public void TakeLife()
    {
        lifeCounter --;

        if(lifeCounter == 0)
        {
            print("Game Over!");

        }
    }

    public int GetLifeCounter()
    {
        return lifeCounter;
    }
}

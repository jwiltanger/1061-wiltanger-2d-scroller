using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static GameManage instance; //to be accessible easily to others

    public GameObject winText;
    public GameObject loseText;
    public GameObject restartText;
    public GameObject startText;
    public GameObject goalText;
    public GameObject witch;
    public AudioClip scream;

    public bool gameOver = false;

    public Text scoreText;
    private int score = 0;
    public Text healthText;
    private int health = 3;



    // Start is called before the first frame update
    void Awake()
    {
        //make sure no other insatnces of Game Manager
        if(instance== null)
        {
            instance = this; 
        }
        else if (instance != null)
        {
            Destroy(gameObject); //destroys self
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ScorePoint()
    {
        if(gameOver)
        {
            return; //can't score if game is over
        }
        score++; //increase score if potion collected
        scoreText.text = "SCORE: " + score.ToString(); //display updated score
        if(score >= 15) //adjust this later after playing
        {
            Wins();
        }
    }

    //reduces health by one point when hit by fireball
    public void DealDamage()
    {
        if (gameOver)
        {
            return;
        }
        health--;
        healthText.text = "Health: " + health.ToString(); //display updated score
        if (health <=0)
        {
            Loses(); //end game if health is 0
        }

    }

    /*called when witch wins the game
     * Displays game over ui and ends game
     **/
    public void Wins()
    {
        winText.SetActive(true); //display ui
        restartText.SetActive(true);
        //keep witch awake when wins, just cause I want to
        gameOver = true; //end game
    }

    /*called when witch gets hit 3 times and dies
     * Displays game over ui and ends game
     **/
    public void Loses() 
    {
        AudioSource.PlayClipAtPoint(scream, transform.position);//play scream
        loseText.SetActive(true); //display ui
        restartText.SetActive(true);
        witch.SetActive(false); //witch disappears
        gameOver = true; //end game
    }

}

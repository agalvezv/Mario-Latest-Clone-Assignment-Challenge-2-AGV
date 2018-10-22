using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float timeLeft = 60;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public AudioClip collectCoin;


    // Use this for initialization
    void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("MarioAssignment3");
        }
	}

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "Castle")
            {
            CountScore();
        }
        if (trig.gameObject.tag =="PickUp")
        {
            GetComponent<AudioSource>().PlayOneShot(collectCoin, 0.5f);
            playerScore += 1;
            Destroy (trig.gameObject);
            

        }

    }

    void CountScore ()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
    

    }
}



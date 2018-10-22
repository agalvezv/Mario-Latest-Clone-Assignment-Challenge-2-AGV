using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public int life;
 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -13)
        {
            Die();
        }
      
	
	}

    void Die ()
    {
        SceneManager.LoadScene("MarioAssignment3");
    }
}

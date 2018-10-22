using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    private AudioSource source;
    public AudioClip JumpS;
  


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
     
    
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        PlayerRaycast();

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
          
        }

        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);

        }

       if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
       else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        
        }

        gameObject.GetComponent<Rigidbody2D > ().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void Jump()
    {
        source.PlayOneShot(JumpS);


        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
    
    }

    void PlayerRaycast ()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "PUBox")
        {
            Destroy (rayUp.collider.gameObject);


        }

        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy>().enabled = false;

        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "Enemy")
        {
            isGrounded = true;

        }
    }
}

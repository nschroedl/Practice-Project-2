using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public bool isAlive;

    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotDelayCounter;

    public float swordDelay;
    private float swordDelayCounter;

    private Animator anim;

    public float knockback;
    public float knockbackCount;
    public float knockbackLength;
    public bool knockFromRight;

    private Rigidbody2D myrigidbody2D;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myrigidbody2D = GetComponent<Rigidbody2D>(); ;
        isAlive = true;
	}
	
    // Occurs a set number of times per second
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
        
    }

	// Update is called once per frame
	void Update () {

        if (grounded)
        {
            doubleJumped = false;
            
        }

        anim.SetBool("grounded", grounded);

        if (Input.GetButton("Jump") && grounded )
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        if (knockbackCount <= 0)
        {
            myrigidbody2D.velocity = new Vector2(moveVelocity, myrigidbody2D.velocity.y);
        } else
        {
            if (knockFromRight)
            {
                myrigidbody2D.velocity = new Vector2(-knockback, knockback);
            } else
            {
                myrigidbody2D.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }       

        anim.SetFloat("speed", Mathf.Abs(myrigidbody2D.velocity.x));

        if (myrigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (myrigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{            
        //    Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
        //    shotDelayCounter = shotDelay;
        //}

        shotDelayCounter -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {           
            if(shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            }

        }

        if(anim.GetBool("sword"))
        {
            anim.SetBool("sword", false);
        }

        swordDelayCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Fire2"))
        {            
            if (swordDelayCounter <= 0)
            {
                swordDelayCounter = swordDelay;
                anim.SetBool("sword", true);
            }
            
        }
    }

    private void Jump()
    {
       
        anim.SetBool("grounded", false);
        myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight);
    }
}

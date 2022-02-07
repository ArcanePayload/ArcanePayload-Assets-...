using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component references
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    //movement variables
    private float hVelo;
    public float speed = 4;
    private float vertVelo;
    public float jumpForce = 5.5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;


    //Ground 
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundlayer;
    private bool isGrounded;

    //health variables
    public int health; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveH();
        Jump();
        CheckIfGrounded();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }





    void MoveH()
    {    //making charater move//

        float x = Input.GetAxisRaw("Horizontal");
        hVelo = x * speed;
        rb.velocity = new Vector2(hVelo, rb.velocity.y);

        //making animations go burrrrrr//

        anim.SetFloat("Speed", Mathf.Abs(hVelo));

        if (x > 0)
        {
            sr.flipX = false;
        }

       else if (x < 0)
        {
            sr.flipX = true;
        }



    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            vertVelo = jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, vertVelo);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        anim.SetFloat("yVelo", rb.velocity.y);

    }


    void CheckIfGrounded()
    {
        Collider2D gCollider = Physics2D.OverlapCircle(
            isGroundedChecker.position,
            checkGroundRadius,
            groundlayer);

        if(gCollider != null)
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
        anim.SetBool("Grounded", isGrounded);
    } 


}

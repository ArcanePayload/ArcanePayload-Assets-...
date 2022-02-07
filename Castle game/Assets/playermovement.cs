using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //Componet referneces
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    //Movement variables
    private float horizVelocity;
    private float vertVelocity;
    public float fallMulitplier = 2.5f;
    public float lowJumpMulitplier = 2f;

    //Ground Checking Variables
    private bool isGrounded;
    public Transform isGroundedChecker;
    public float CheckGroundRadius;
    public LayerMask groundLayer;

    public float speed = 4;
    public float jumpforce = 5.5f;


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
        jump();
        CheckIfGrounded();
    }

    void MoveH()
    {
        float x = Input.GetAxisRaw("Horizontal");
        horizVelocity = x * speed;
        rb.velocity = new Vector2(horizVelocity, rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(horizVelocity));

        if (x > 0)
        {
            sr.flipX = false;
        }
        else if (x < 0)
        {
            sr.flipX = true;
        }

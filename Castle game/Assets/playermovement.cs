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

    public float speed = 4;



    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.position += Vector3.up * speed * Time.deltaTime;



        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.position += Vector3.up * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.position += Vector3.right * -speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.position += Vector3.right * speed * Time.deltaTime;

        }
    }
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


   void update()
    {
        if(Input.GetKey(KeyCode.W))
    }
}
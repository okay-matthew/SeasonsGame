using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Script for player character behavior.
*/

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb; 
    private Animator am;
    private SpriteRenderer sprite;

    private float x_dir = 0;
    [SerializeField] public float move_speed = 4f;
    [SerializeField] public float jump_speed = 7f;

    private bool grounded = false; //when true, player can jump
    public Transform groundedChecker; //indicates where feet are to check if they're on the ground
    public float checkGroundRadius; //radius around groundedChecker to see if its overlapping ground
    public LayerMask groundLayer; //links to ground layer
    public bool unpaused; //controls player movement during transitions
    private enum PlayerState { idle, running, jumping, falling}


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>(); // grabs the rigid body of the player, which allows it to collide with the ground
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        unpaused = true;
    }

    // Update is called once per frame
    void Update() {
        if (unpaused) { // pause for shrine interaction. Prevents player from moving shrine transition
            Move();
            Jump();
            CheckGrounded();
            UpdatePlayerAnimation();
        }
    }
    /* 
        Manages the player animation based on x direction and y velocity

        NOTE: y velocity fluctuates. It is usually not zero, so the animation trigger must 
        account for this.
    */
    private void UpdatePlayerAnimation() {

        PlayerState state;

        if (x_dir > 0f) {
            state = PlayerState.running;
            sprite.flipX = false;
        } else if (x_dir < 0f) {
            state = PlayerState.running;
            sprite.flipX = true;
        } else {
            state = PlayerState.idle;
        }

        if (rb.velocity.y >= 0.01f) {
            state = PlayerState.jumping;
            
        } else if (rb.velocity.y <= -0.01f) {
            state = PlayerState.falling;
        }

        am.SetInteger("state", (int)state);
    }

    /*
        Moves player horizontally 
    */
    private void Move(){
        x_dir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_dir * move_speed, rb.velocity.y);
    }

    /*
        Controls jump
    */
    private void Jump(){
         if (Input.GetButtonDown("Jump") && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
         }
    }

    /*
        finds position of groundedChecker and uses the radius to determine whether the circle is overlapping anything on the ground layer
        returns true if its touching or false if its not
    */
    private void CheckGrounded(){
        grounded = Physics2D.OverlapCircle(groundedChecker.position, checkGroundRadius, groundLayer);
    }
}

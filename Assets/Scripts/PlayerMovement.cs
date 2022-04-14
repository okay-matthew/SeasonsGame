using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Animator am;
    private SpriteRenderer sprite;

    private float x_dir = 0;
    [SerializeField] private float move_speed = 4f;
    [SerializeField] private float jump_force = 400f;

    private bool grounded = false; //when true, player can jump
    public Transform groundedChecker; //indicates where feet are to check if they're on the ground
    public float checkGroundRadius; //radius around groundedChecker to see if its overlapping ground
    public LayerMask groundLayer; //links to ground layer

    private enum PlayerState { idle, running, jumping, falling}



    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>(); // grabs the rigid body of the player, which allows it to collide with the ground
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        Move();

        Jump();

        CheckGrounded();

        UpdatePlayerAnimation();
    }

    private void UpdatePlayerAnimation() {

        PlayerState state;

        if (x_dir > 0f) {
            state = PlayerState.running;
            sprite.flipX = false;
        } 
        else if (x_dir < 0f) {
            state = PlayerState.running;
            sprite.flipX = true;
        }
        else {
            state = PlayerState.idle;
        }

        if (rb.velocity.y >= 0.01f) {
            state = PlayerState.jumping;
            
        }
        else if (rb.velocity.y <= -0.01f) {
            state = PlayerState.falling;
        }

        // Debug.Log(state);

        am.SetInteger("state", (int)state);
    }

    private void Move(){
        x_dir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_dir * move_speed, rb.velocity.y);
    }

    private void Jump(){
         if (Input.GetButtonDown("Jump") && grounded) {
            rb.AddForce(new Vector2(0f, jump_force));
         }
    }

    private void CheckGrounded(){
        //finds position of groundedChecker and uses the radius to determine whether the circle is overlapping anything on the ground layer
        //returns true if its touching or false if its not
        grounded = Physics2D.OverlapCircle(groundedChecker.position, checkGroundRadius, groundLayer);
    }
}

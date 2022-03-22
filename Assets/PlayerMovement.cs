using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Animator am;
    private SpriteRenderer sprite;

    public List<string> orbsList;
    public int orbCount;
    public Text orbText;


    private float x_dir = 0;
    private bool grounded;

    [SerializeField] private float move_speed = 4f;
    [SerializeField] private float jump_force = 400f;

    private enum PlayerState { idle, running, jumping, falling}
    

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>(); // grabs the rigid body of the player, which allows it to collide with the ground
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        // list that holds each orb name
        orbsList = new List<string>();
        // text on the screen about # of orbs collected
        orbText.text = "Orbs Collected: " + orbCount.ToString() + "/3";
    }

    // Update is called once per frame
    void Update() {

        grounded = false;

        x_dir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_dir * move_speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            // Debug.Log("hello");
            rb.AddForce(new Vector2(0f, jump_force));
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }

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
        else if (rb.velocity.y <= -0.1f) {
            state = PlayerState.falling; //TODO: Must have 'ground' check to have animations work
        }

        Debug.Log(state);

        am.SetInteger("state", (int)state);
    }

    // handles collisions
     private void OnTriggerEnter2D(Collider2D collision) {
         // if the player touches the orb, get the name of the orb, add it to the list, increment orbCount, delete the orb
       if(collision.CompareTag("Orb Collectable")) {
            string orbName = collision.gameObject.GetComponent<OrbScript>().orbName;
            orbsList.Add(orbName);
            orbCount = orbsList.Count;
            orbText.text = "Orbs collected: "+ orbCount.ToString() + "/3";
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Manages everything to do with orb collection & orbs following player
*/
public class OrbScript : MonoBehaviour
{
    private int orbCount; // counts number of orbs collected to display as text on screen
    public Text orbText; // orb text that appears in the corner of the screen to indicate how many orbs have been collected
    public List<GameObject> orbList; // list of orbs that have been collected
    private bool startFollow; // true when orb should be following player, false otherwise
    public float orbSpeed; // speed of orb (modifiable in unity)
    private Transform playerTarget; // transform to store player position information (for use when player is a target)
    private GameObject orb1, orb2, orb3; // 3 orb GameObjects
    private Transform orb1Transform, orb2Transform, orb3Transform; // transforms to store orb GameObject position information
    private bool orb1Touching, orb2Touching, orb3Touching; // true when player has touched the corresponding orb
    private Transform orb1Target, orb2Target, orb3Target; // transforms to store position information about the target of each orb
    private double distance; // distance each orb will stay away from target


    private void Start() {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        orb1 = GameObject.Find("Orb 1");
        orb2 = GameObject.Find("Orb 2");
        orb3 = GameObject.Find("Orb 3");
        orb1Transform = orb1.GetComponent<Transform>();
        orb2Transform = orb2.GetComponent<Transform>();
        orb3Transform = orb3.GetComponent<Transform>();
        startFollow = false;
        orbCount = 0;
        orbText.text = "Orbs Collected: " + orbCount.ToString() + "/3"; // creates the orb text
        distance = 0.4;
    }

    // if the player is touching the indicated orb and if it should start following, start to catch orb
    private void Update() {
        if(startFollow && orb1Touching){
            startCatchOrb(orb1, orb1Target);
        }
        if(startFollow && orb2Touching){
            startCatchOrb(orb2, orb2Target);
        }
        if(startFollow && orb3Touching){
            startCatchOrb(orb3, orb1Target);
        }
    }

    /**
    * If the player touches the orb, check which orb it is touching
    */
     private void OnTriggerEnter2D(Collider2D collision) {
        checkTouch(collision.CompareTag("Orb1"), orb1);
        checkTouch(collision.CompareTag("Orb2"), orb2);
        checkTouch(collision.CompareTag("Orb3"), orb3);
    }

    /**
    * When the orb should start following the player (startFollow = true) and the player is touching the GameObject orb,
    * method checks which orbs were collected in what order and determines the orb's target based on when it was collected.
    * The target of the newly collected orb becomes the orb that was last collected (except for the first orb, whose target
    * is the player). Then calls moveOrb.
    */
    private void startCatchOrb(GameObject orb, Transform orbTarget){
        if(orbList[0].Equals(orb)){ //if orb is first in the orb list (= collected first)
            orbTarget = playerTarget; // then orb should have player as a target
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        } else if(orbList[1].Equals(orb)){ // if orb is second in the orb list (= collected second)
            orbTarget = orbList[0].GetComponent<Transform>(); //then orb should have first orb in the list as its target
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        } else if(orbList[2].Equals(orb)){ //if orb is third in the orb list (= collected last)
            orbTarget = orbList[1].GetComponent<Transform>(); // then orb should have second orb in the list as its target
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        }
    }

    /**
    * Increments orb count, changes orb text to "count/3", and starts orb following the player
    */
    private void catchOrb(GameObject currentOrb){
        if(!orbList.Contains(currentOrb)){ // if current orb hasn't already been collected
            orbList.Add(currentOrb);
            currentOrb.tag = "OrbFound"; // change tag for use in orb depositor script to keep track of whether all 3 orbs have been collected
            orbCount ++;
        }
        orbText.text = "Orbs collected: "+ orbCount.ToString() + "/3";
        startFollow = true;
    }

    /**
    * Updates orb position to follow the orb's target
    * Orb moving toward code rules inspired by/adapted from: https://www.youtube.com/watch?v=rhoQd6IAtDo
    */
    private void moveOrb(Transform orb, Transform orbTarget){
        if(Vector2.Distance(orb.position, orbTarget.position) > distance){ // if the orb is more than a certain distance away from its target
                orb.position = Vector2.MoveTowards(orb.position, orbTarget.position, orbSpeed * Time.deltaTime); // move towards target
            }
    }

    /**
    * Set the correct orb touch checker to true and catches the touched orb
    */
    private void checkTouch(bool tagCompare, GameObject orb){
        if(tagCompare){
            checkWhichTouch(orb);
            catchOrb(orb);
        }
    }

    /**
    * Sets orb touching checker bool to true depending on which orb player touched when called
    */
    private void checkWhichTouch(GameObject orb){
        if(orb.Equals(orb1)){
            orb1Touching = true;
        } else if(orb.Equals(orb2)){
            orb2Touching = true;
        } else if(orb.Equals(orb3)){
            orb3Touching = true;
        }
    }
}
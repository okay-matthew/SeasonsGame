using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Manages everything to do with orb collection & orbs following player
*/
public class OrbScript : MonoBehaviour
{
    private int orbCount;
    public Text orbText;
    public List<GameObject> orbList;
    private bool startFollow;
    public float orbSpeed;
    private Transform playerTarget;
    private GameObject orb1, orb2, orb3;
    private Transform orb1Transform, orb2Transform, orb3Transform;
    private bool orb1Touching, orb2Touching, orb3Touching;
    private Transform orb1Target, orb2Target, orb3Target;
    private double distance;


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
        orbText.text = "Orbs Collected: " + orbCount.ToString() + "/3";
        distance = 0.4;
    }
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
        if(orbList[0].Equals(orb)){
            orbTarget = playerTarget;
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        } else if(orbList[1].Equals(orb)){
            orbTarget = orbList[0].GetComponent<Transform>();
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        } else if(orbList[2].Equals(orb)){
            orbTarget = orbList[1].GetComponent<Transform>();
            moveOrb(orb.GetComponent<Transform>(), orbTarget);
        }
    }

    /**
    * Increments orb count, changes orb text to "count/3", and starts orb following the player
    */
    private void catchOrb(GameObject currentOrb){
        if(!orbList.Contains(currentOrb)){
            orbList.Add(currentOrb);
            currentOrb.tag = "OrbFound";
            orbCount ++;
        }
        orbText.text = "Orbs collected: "+ orbCount.ToString() + "/3";
        startFollow = true;
    }

    /**
    *  Updates orb position to follow the orb's target
    */
    private void moveOrb(Transform orb, Transform orbTarget){
        if(Vector2.Distance(orb.position, orbTarget.position) > distance){
                orb.position = Vector2.MoveTowards(orb.position, orbTarget.position, orbSpeed * Time.deltaTime);
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
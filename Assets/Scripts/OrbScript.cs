using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbScript : MonoBehaviour
{

    public int orbCount;
    public Text orbText;
    public List<GameObject> orbList;
    private bool startFollow;

    public float speed;
    private Transform playerTarget;
    private Transform orb1;
    private Transform orb2;
    private Transform orb3;

    private bool touching1;
    private bool touching2;
    private bool touching3;
    private double orb1Distance;
    private double orb2Distance;
    private double orb3Distance;


    private void Start() {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        orb1 = GameObject.Find("Orb 1").GetComponent<Transform>();
        orb2 = GameObject.Find("Orb 2").GetComponent<Transform>();
        orb3 = GameObject.Find("Orb 3").GetComponent<Transform>();
        startFollow = false;
        orbCount = 0;
        orb1Distance = 0.7;
        orb2Distance = 0.7;
        orb3Distance = 0.7;
        orbText.text = "Orbs Collected: " + orbCount.ToString() + "/3";
    }

    private void Update() {
        if(startFollow && touching1 && Vector2.Distance(orb1.position, playerTarget.position) > orb1Distance){
            moveOrb(orb1);
            if(orbList.Contains(GameObject.Find("Orb 1"))){
                if(orbList[0] == GameObject.Find("Orb 1")){
                    orb1Distance = 0.6;
                } else if(orbList[1] == GameObject.Find("Orb 1")){
                    orb1Distance = 0.9;
                } else if(orbList[2] == GameObject.Find("Orb 1")){
                    orb1Distance = 1.2;
                }
            }
        }
        if(startFollow && touching2 && Vector2.Distance(orb2.position, playerTarget.position) > orb2Distance){
            moveOrb(orb2);
            if(orbList.Contains(GameObject.Find("Orb 2"))){
                if(orbList[0] == GameObject.Find("Orb 2")){
                    orb2Distance = 0.6;
                } else if(orbList[1] == GameObject.Find("Orb 2")){
                    orb2Distance = 0.9;
                } else if(orbList[2] == GameObject.Find("Orb 2")){
                    orb2Distance = 1.2;
                }
            }       
        }
        if(startFollow && touching3 && Vector2.Distance(orb3.position, playerTarget.position) > orb3Distance){
            moveOrb(orb3);
            if(orbList.Contains(GameObject.Find("Orb 3"))){
                if(orbList[0] == GameObject.Find("Orb 3")){
                    orb3Distance = 0.6;
                } else if(orbList[1] == GameObject.Find("Orb 3")){
                    orb3Distance = 0.9;
                } else if(orbList[2] == GameObject.Find("Orb 3")){
                    orb3Distance = 1.2;
                }
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D collision) {
        // if the player touches the orb, get the name of the orb, add it to the list, increment orbCount, delete the orb
       if(collision.CompareTag("Orb1")) {
            incrementCountChangeTextStartFollow(GameObject.Find("Orb 1"));
            touching1 = true;
        }
        if(collision.CompareTag("Orb2")){
            incrementCountChangeTextStartFollow(GameObject.Find("Orb 2"));
            touching2 = true;
        }
        if(collision.CompareTag("Orb3")){
            incrementCountChangeTextStartFollow(GameObject.Find("Orb 3"));
            touching3 = true;
        }
    }

    private void incrementCountChangeTextStartFollow(GameObject currentOrb){
        if(!orbList.Contains(currentOrb)){
            orbList.Add(currentOrb);
            currentOrb.tag = "OrbFound";
            orbCount ++;
        }
        orbText.text = "Orbs collected: "+ orbCount.ToString() + "/3";
        startFollow = true;
    }

    private void moveOrb(Transform orb){
        orb.position = Vector2.MoveTowards(orb.position, playerTarget.position, speed * Time.deltaTime);
    }
}
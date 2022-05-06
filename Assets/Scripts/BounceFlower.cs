using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Script for the handling of bounciness when jumping on certain objects
 ATTRIBUTION (LITERALLY SAVED MY LIFE BY SHOWING A SOLUTION IN UNDER A
 MINUTE FOR A PROBLEM I WAS SPENDING DAYS ON): 
 Bendux [https://www.youtube.com/watch?v=0e3Ld6-RzIU}]
*/


public class BounceFlower : MonoBehaviour
{

    private float bounce = 7f;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}

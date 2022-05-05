using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOrb : MonoBehaviour
{
    //https://forum.unity.com/threads/how-to-make-an-object-move-up-and-down-on-a-loop.380159/
    public AnimationCurve myCurve;
   
    void Update(){
        // transform.position = new Vector3(transform.position.x, GameObject.Find("Agate").GetComponent<Transform>().position.y, transform.position.z);
        // if(GameObject.Find("Agate").GetComponent<PlayerMovement>().grounded){
            transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    When starting from the main menu, it preserves the music after beginning the game.
*/

public class AudioPreserve : MonoBehaviour
{
   void Awake()
   {
       DontDestroyOnLoad(transform.gameObject);
   }
}

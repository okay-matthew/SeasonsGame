using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{

    [SerializeField]
    private Tilemap terrain, background, backgroundObjects;
    
    private bool inKillzone = false;

    void Update() {
        if (inKillzone) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            inKillzone = true;
        }
    }
}

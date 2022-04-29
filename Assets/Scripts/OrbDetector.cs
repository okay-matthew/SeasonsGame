using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrbDetector : MonoBehaviour
{
    private bool orbsDeposited;
    private bool touchingOrbDepositor;
    public Image enterKey; //Image: https://www.google.com/url?sa=i&url=http%3A%2F%2Fpixelartmaker.com%2Fart%2Fb868ed6b29546ba&psig=AOvVaw3T2i_1zYvFfdEcik9jnmgU&ust=1650562955901000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCKCduKeYo_cCFQAAAAAdAAAAABAD ; maybe make our own instead?
    public Text levelCompleteText;
    private int count;



    // Start is called before the first frame update
    void Start()
    {
        touchingOrbDepositor = false;
        levelCompleteText.text = "";
        count = 0;
        enterKey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrbsDeposited();
        
        if(Input.GetKeyDown(KeyCode.R)){
                    Time.timeScale = 1;
                }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            touchingOrbDepositor = true;
        } 
    }
    private void CheckOrbsDeposited() {
        if(touchingOrbDepositor && GameObject.FindGameObjectsWithTag("OrbFound").Length == 3){    
            enterKey.enabled = true;
            if(Input.GetButtonDown("Submit")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelCompleteText.text = "Level Complete";
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            count++;
            touchingOrbDepositor = false;
            enterKey.enabled = false;
        }
    }
}

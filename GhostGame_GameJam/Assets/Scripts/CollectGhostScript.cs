using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGhostScript : MonoBehaviour{

    private bool onObject;

    void OnTriggerEnter2D (Collider2D col){
      onObject = true;
    }

    void OnTriggerExit2D (Collider2D col){
      onObject = false;
    }

    void Update(){
      if(onObject && Input.GetKeyDown(KeyCode.E)){

        if(gameObject.tag == "Orange"){
          MysteryManager.instance.ghostCollected = "orange";
          MysteryManager.instance.orangeGhostCollected = true;
        }
        if(gameObject.tag == "Teal"){
          MysteryManager.instance.ghostCollected = "teal";
          MysteryManager.instance.tealGhostCollected = true;
        }
        if(gameObject.tag == "Pink"){
          MysteryManager.instance.ghostCollected = "pink";
          MysteryManager.instance.pinkGhostCollected = true;
        }

        Destroy(gameObject);
      }
    }

}

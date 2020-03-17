using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPickUpScript : MonoBehaviour{

    private bool onObject;
    public Item item;

    void Start(){
    }

    void Update(){
      // hover and press E to pick up object
      if(onObject && Input.GetKeyDown(KeyCode.E)){
        PickUp();
      }

    }

    void OnTriggerEnter2D (Collider2D col){
      onObject = true;
    }

    void OnTriggerExit2D (Collider2D col){
      onObject = false;
    }

    void PickUp(){
      Debug.Log("Picked up" + item.name);
      // Add To inventory
      GhostInvScriptLuca.instance.Add(item);
      Destroy(gameObject);
    }
}

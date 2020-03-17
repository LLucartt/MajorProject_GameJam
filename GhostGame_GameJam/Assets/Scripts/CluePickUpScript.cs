using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePickUpScript : MonoBehaviour{

  private bool onObject;
  public Clue clue;
  public string clueColour;

  void Start(){
  }

  void Update(){
    //itemNumber = GhostInvScriptLuca.instance.items[i];

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
    if(clueColour == "Orange"){
      MysteryManager.instance.AmountOfOrangeClues += 1;
    }
    if(clueColour == "Teal"){
      MysteryManager.instance.AmountOfTealClues += 1;
    }
    if(clueColour == "Pink"){
      MysteryManager.instance.AmountOfPinkClues += 1;
    }

    Destroy(gameObject);
  }
}

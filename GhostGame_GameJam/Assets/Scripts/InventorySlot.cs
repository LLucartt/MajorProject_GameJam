using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour{

  public Image icon;
  public Button removeButton;
  public Button mainButton;
  public Button secondaryButton;

  public Image mainslotIcon;
  public Image secondslotIcon;

  bool isMainGhost;
  bool isSecondGhost;

  public float CluesforThisSlot;

  Item item;

  public bool ghostCollected = false;

  public void AddItem(Item newItem){
    item = newItem;
    icon.sprite = item.icon;
    icon.enabled = true;
  }

  public void OnRemoveButton(){
    if(isMainGhost){
      //remove main ghost
      MainSlotScipt.instance.RemoveMain(item);
      mainslotIcon.enabled = false;
      isMainGhost = false;

      //when removing main ghost, also remove second ghost
      MainSlotScipt.instance.RemoveSecondary(item);
      secondslotIcon.enabled = false;
      isSecondGhost = false;

      removeButton.interactable = false;
    }

    //when removing second ghost only remove second and keep main ghost
    else if(isSecondGhost){
      MainSlotScipt.instance.RemoveSecondary(item);
      secondslotIcon.enabled = false;
      removeButton.interactable = false;
      isSecondGhost = false;
    }
  }

  public void AddMainButton(){
    if(MainSlotScipt.instance.MainGhostActivated == ""){
      mainslotIcon.sprite = item.icon;
      mainslotIcon.enabled = true;
      MainSlotScipt.instance.AddMain(item);

      removeButton.interactable = true;
      isMainGhost = true;
    }
  }

  public void AddSecondaryButton(){
    if(MainSlotScipt.instance.SecondaryGhostActivated == ""){
      secondslotIcon.sprite = item.icon;
      secondslotIcon.enabled = true;
      MainSlotScipt.instance.AddSecondary(item);

      removeButton.interactable = true;
      isSecondGhost = true;
    }
  }

  public void UseItem(){
    if(item != null){
      MysteryManager.instance.onclick = "";
      if( item.name == "Explosion Ghost"){
        MysteryManager.instance.onclick = "orange";
      }
      if( item.name == "Trail Ghost"){
        MysteryManager.instance.onclick = "teal";
      }
      if( item.name == "Fire Ghost"){
        MysteryManager.instance.onclick = "pink";
      }
      item.Use();
    }
  }

void Update(){


  if(item != null){
    if( item.name == "Explosion Ghost"){
      CluesforThisSlot = MysteryManager.instance.AmountOfOrangeClues;
      if(MysteryManager.instance.ghostCollected == "orange"){
        ghostCollected = true;
        MysteryManager.instance.ghostCollected = "";
      }
    }
    if( item.name == "Trail Ghost"){
      CluesforThisSlot = MysteryManager.instance.AmountOfTealClues;
      if(MysteryManager.instance.ghostCollected == "teal"){
        ghostCollected = true;
        MysteryManager.instance.ghostCollected = "";
      }
    }
    if( item.name == "Fire Ghost"){
      CluesforThisSlot = MysteryManager.instance.AmountOfPinkClues;
      if(MysteryManager.instance.ghostCollected == "pink"){
        ghostCollected = true;
        MysteryManager.instance.ghostCollected = "";
      }
    }
  }

  if(item != null && ghostCollected){
    //stage 1: show all main equip button when there is no main ghost
    if(MainSlotScipt.instance.MainGhostActivated == "" && item != null){
      mainButton.interactable = true;
      secondaryButton.interactable = false;
      removeButton.interactable = false;
      isMainGhost = false;
      isSecondGhost = false;
    }



      // if there is main ghost & no secondary ghost, hide all equip main buttons
      else if(MainSlotScipt.instance.MainGhostActivated != "" && MainSlotScipt.instance.SecondaryGhostActivated == "" && item != null){
        mainButton.interactable = false;

        // if ghost is not main or secondary ghost, it can become second ghost
        if(!isMainGhost && !isSecondGhost){
          secondaryButton.interactable = true;
        }
      }

      // if there is a secondary  ghost, hide all equip second buttons
      else if(MainSlotScipt.instance.SecondaryGhostActivated != "" && item != null){
        secondaryButton.interactable = false;
      }

      // if there is a main and second ghost, hide all equip buttons
      else if(MainSlotScipt.instance.SecondaryGhostActivated != "" && MainSlotScipt.instance.MainGhostActivated != ""){
        secondaryButton.interactable = false;
        mainButton.interactable = false;
      }
  }
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour{

    GhostInvScriptLuca inventory;
    public GameObject inventoryUI;
    public Transform itemsParent;
    InventorySlot[] slots;



    void Start(){
      inventory = GhostInvScriptLuca.instance;
      inventory.OnItemChangedCallback += UpdateUI;
      slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update(){
      if(Input.GetKeyDown(KeyCode.Q)){
        inventoryUI.SetActive(!inventoryUI.activeSelf);
      }
    }

    void UpdateUI(){
        for (int i = 0; i < slots.Length; i++){
          if(i < inventory.items.Count){
            slots[i].AddItem(inventory.items[i]);
          } 
        }
    }
}

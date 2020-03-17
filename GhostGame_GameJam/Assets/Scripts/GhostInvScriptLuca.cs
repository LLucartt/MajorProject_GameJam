using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInvScriptLuca : MonoBehaviour{

    // Singleton start

    public static GhostInvScriptLuca instance;

    void Awake(){
      if (instance != null){
        Debug.LogWarning("More than one instance of Inventory found!");
        return;
      }

      instance = this;
    }

    // Singleton end

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public List<Item> items = new List<Item>();

    //adding items/ ghosts to inventory
    public void Add (Item item){
      if(!item.isDefaultItem){
        items.Add(item);
        if(OnItemChangedCallback != null){
          OnItemChangedCallback.Invoke();
        }
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSlotScipt : MonoBehaviour{

    // Singleton start

    public static MainSlotScipt instance;

    void Awake(){
      if (instance != null){
        Debug.LogWarning("More than one instance of mainslot found!");
        return;
      }

      instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    // Singleton end

    public GameObject[] SpacialAbilities;
    public GameObject player;
    public Transform PlayerLocation;

    public string MainGhostActivated;
    public string SecondaryGhostActivated;

    void Update(){
      PlayerLocation = player.transform;
    }

    public void AddMain (Item item){
        if(MainGhostActivated == ""){
          MainGhostActivated = item.name;
          Debug.Log("mainghost: " + item.name);

          if(OnItemChangedCallback != null){
            OnItemChangedCallback.Invoke();
          }
        }
    }

    public void RemoveMain (Item item){
      MainGhostActivated = "";

      if(OnItemChangedCallback != null){
        OnItemChangedCallback.Invoke();
      }
    }

    public void AddSecondary (Item item){
      if(SecondaryGhostActivated == ""){
        SecondaryGhostActivated = item.name;

        if(OnItemChangedCallback != null){
          OnItemChangedCallback.Invoke();
        }
      }
    }

    public void RemoveSecondary (Item item){
      SecondaryGhostActivated = "";

      if(OnItemChangedCallback != null){
        OnItemChangedCallback.Invoke();
      }
    }

    public void specialAbility(){
      if(MainGhostActivated == "Explosion Ghost" && SecondaryGhostActivated == ""){
            Instantiate(SpacialAbilities[0], PlayerLocation);
      }
      else if(MainGhostActivated == "Explosion Ghost" && SecondaryGhostActivated == "Fire Ghost"){
            Instantiate(SpacialAbilities[3], PlayerLocation);
      }
      else if(MainGhostActivated == "Explosion Ghost" && SecondaryGhostActivated == "Trail Ghost"){
            Instantiate(SpacialAbilities[4], PlayerLocation);
      }


      else if(MainGhostActivated == "Fire Ghost" && SecondaryGhostActivated == ""){
            Instantiate(SpacialAbilities[1], PlayerLocation);
      }
      else if(MainGhostActivated == "Fire Ghost" && SecondaryGhostActivated == "Explosion Ghost"){
            Instantiate(SpacialAbilities[5], PlayerLocation);
      }
      else if(MainGhostActivated == "Fire Ghost" && SecondaryGhostActivated == "Trail Ghost"){
            Instantiate(SpacialAbilities[6], PlayerLocation);
      }



      else if(MainGhostActivated == "Trail Ghost" && SecondaryGhostActivated == ""){
            Instantiate(SpacialAbilities[2], PlayerLocation);
      }
      else if(MainGhostActivated == "Trail Ghost" && SecondaryGhostActivated == "Fire Ghost"){
            Instantiate(SpacialAbilities[7], PlayerLocation);
      }
      else if(MainGhostActivated == "Trail Ghost" && SecondaryGhostActivated == "Explosion Ghost"){
            Instantiate(SpacialAbilities[8], PlayerLocation);
      }

    }
}

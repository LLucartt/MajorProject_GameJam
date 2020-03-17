using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysteryManager : MonoBehaviour{

  // Singleton start

  public static MysteryManager instance;

  void Awake(){
    if (instance != null){
      Debug.LogWarning("More than one instance of manager found!");
      return;
    }

    instance = this;
  }

  // Singleton end

  public float AmountOfOrangeClues = 0;
  public float AmountOfTealClues = 0;
  public float AmountOfPinkClues = 0;

  public Text WhoInut;
  public Text WhenInut;
  public Text HowInut;
  public Text WhereInut;

  public GameObject QuestUI;
  public GameObject findGhostButton;
  public GameObject ghostObject;
  private SpriteRenderer spriteRenderer;
  public string ghostCollected;

  public string onclick = "";

  private bool QuestUIActivated = false;
  public bool orangeGhostCollected = false;
  public bool tealGhostCollected = false;
  public bool pinkGhostCollected = false;


    void Start(){
    }


    void Update(){
      if(onclick == "orange"){
        resetWordClues();

        if(AmountOfOrangeClues >= 1){
          WhoInut.text = "Draco of Athens";
        }
        if(AmountOfOrangeClues >= 2){
          WhenInut.text = "620 BC";
        }
        if(AmountOfOrangeClues >= 3){
          HowInut.text = "smothered to death by gifts of cloaks and hats showered upon him by appreciative citizens";
        }
        if(AmountOfOrangeClues >= 4){
          WhereInut.text = "theatre on Aegina";
          if(ghostCollected == "" && !orangeGhostCollected){
            ghostObject = GameObject.FindGameObjectWithTag("Orange");
            spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
            findGhostButton.SetActive(true);
          }
        }
      }
      else if(onclick == "teal"){
        resetWordClues();

        if(AmountOfTealClues >= 1){
          WhoInut.text = "Agathocles";
        }
        if(AmountOfTealClues >= 2){
          WhenInut.text = "289 BC";
        }
        if(AmountOfTealClues >= 3){
          HowInut.text = "murdered with a poisoned toothpick";
        }
        if(AmountOfTealClues >= 4){
          WhereInut.text = "Syracuse";
          if(ghostCollected == "" && !tealGhostCollected){
            ghostObject = GameObject.FindGameObjectWithTag("Teal");
            spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
            findGhostButton.SetActive(true);
          }
        }
      }
      else if(onclick == "pink"){
        resetWordClues();

        if(AmountOfPinkClues >= 1){
          WhoInut.text = "Henry";
        }
        if(AmountOfPinkClues >= 2){
          WhenInut.text = "1135";
        }
        if(AmountOfPinkClues >= 3){
          HowInut.text = "ate too many dumplings against his physician's advice, causing a pain in his gut and ultimately his death.";
        }
        if(AmountOfPinkClues >= 4){
          WhereInut.text = "food truck";
          if(ghostCollected == "" && !pinkGhostCollected){
            ghostObject = GameObject.FindGameObjectWithTag("Pink");
            spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
            findGhostButton.SetActive(true);
          }
        }
      }
      else{
        resetWordClues();
      }

    }

    public void QuestUi(){
      QuestUI.SetActive(!QuestUI.activeSelf);
      QuestUIActivated = !QuestUIActivated;
      if(QuestUIActivated == false){
        onclick = "";
      }
    }

    public void resetWordClues(){
      findGhostButton.SetActive(false);
      WhoInut.text = "";
      WhenInut.text = "";
      HowInut.text = "";
      WhereInut.text = "";
    }

    public void findGhost(){
      spriteRenderer.enabled = true;
    }

    public void PickUpGhost(){

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newClue", menuName = "Clues/NewClue")]
public class Clue : ScriptableObject{

  new public string name = "newClue";
  public Sprite icon = null;

}

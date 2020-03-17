using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "newItem";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use(){
      MysteryManager.instance.QuestUi();
      Debug.Log("using" + name);
      // use object here/ do something
    }

}

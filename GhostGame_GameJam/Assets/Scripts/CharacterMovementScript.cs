using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour{

    public bool isPlayer2;
    public float speed = 18;
    private Rigidbody2D rig;


    void Start(){
      rig = GetComponent<Rigidbody2D>();
    }

    void Update(){
      if(isPlayer2){
        float hAxis = Input.GetAxis("HorizontalP2");
        float vAxis = Input.GetAxis("VerticalP2");

        Vector3 movement = new Vector3(hAxis, vAxis, 0) * speed * Time.deltaTime;

        rig.MovePosition(transform.position + movement);
      }
      else{
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vAxis, 0) * speed * Time.deltaTime;

        rig.MovePosition(transform.position + movement);
      }

      if(Input.GetKeyDown(KeyCode.Space)){
        MainSlotScipt.instance.specialAbility();
      }



    }
}

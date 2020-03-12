using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
  [SerializeField]
      private float speed; //player speed
      private Rigidbody2D myRigidbody;
      [SerializeField]  private Vector2 change; //player position change


      public GameObject BlockToPickUp;
      public bool pickedUp = false;
      public Rigidbody2D blockRigi;
      private SpriteRenderer myRenderer;

      private void Start()
      {
          myRigidbody = GetComponent<Rigidbody2D>();
          myRenderer = GetComponent<SpriteRenderer>();
      }
      void Update()
      {
          //PLAYER MOVEMENT
          change = Vector2.zero;
          change.x = Input.GetAxisRaw("Horizontal");
          change.y = Input.GetAxisRaw("Vertical");

          if (change != Vector2.zero)
          {
              MoveCharacter();
              change.x = Mathf.Round(change.x);
              change.y = Mathf.Round(change.y);
          }


      }
      void MoveCharacter()
      {
          change.Normalize();
          myRigidbody.MovePosition(myRigidbody.position + change * speed * Time.fixedDeltaTime); //Time.fixedDeltaTime   Time.deltaTime


      }
    }

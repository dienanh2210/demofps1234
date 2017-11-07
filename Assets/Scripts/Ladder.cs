using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
     public GameObject player;
  
    float speed = 0.2f;
  public  bool canClimb = false;
    private Vector3 moveDirection;

   
    void Start () {
       
	}

    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.tag == "Player")
        {
            canClimb = true;
        }


    }
    void OnTriggerExit(Collider coll2) {
        if (coll2.tag == "Player")
        {
            canClimb = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }

        void Update()
    {

        
        if (canClimb)
        {

            

                float x = Input.GetAxis("Horizontal") * speed;
                float h = Input.GetAxis("Vertical") * speed;
            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
            {
                // player.transform.Translate (new Vector3(0,h,0));
                player.GetComponent<Rigidbody>().velocity = new Vector3(-x, h, 0) * 20;
            }
            else {
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;


            }


        }

    }


}

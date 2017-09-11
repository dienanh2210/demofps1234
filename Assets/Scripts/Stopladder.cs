using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopladder : MonoBehaviour {
    private GameObject ladder;
    private GameObject player;
    float speed = 3;
	// Use this for initialization
	void Start () {
		ladder=GameObject.FindGameObjectWithTag("Ladder");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.tag == "Player")
        {
            //  canClimb = true;
            ladder.GetComponent<Ladder>().canClimb=false;
           
            float h = Input.GetAxis("Vertical") * speed;
            Debug.Log("ladder");
            player.transform.Translate (new Vector3(0,0,1));
            //  player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0)*1;
            //player.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*1;
        }

        
    }


   
}

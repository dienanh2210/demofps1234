using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

    private GameObject player;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");


    }
        void Update()
    {

        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 50));

    }


    void OnTriggerEnter(Collider Collider) { 


        if (Collider.tag =="Player") {

            //  player.GetComponent<gunPlayer>().bulletgame = 500;
            float bullet2 = player.GetComponent<gunPlayer>().bulletgame=500;
            player.GetComponent<gunPlayer>().bulletpoint.text = "|" + bullet2.ToString();
            Debug.Log("1000");

            Destroy(gameObject,0.5f);
        }


    }
}

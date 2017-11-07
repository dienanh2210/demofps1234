using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom2 : MonoBehaviour {
     int zoom=35;
        int normal=60;
    float smooth = 8;
    private bool zoomedIn = false;
    public GameObject gun1;
    public GameObject gun2;
   
    private Vector3 olposition;
    

	// Use this for initialization
	void Start () {
       gun1.SetActive(true);
        gun2.SetActive(false);
        

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            zoomedIn = !zoomedIn;
        }
        if (zoomedIn == true)
        {    

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);
            gun2.SetActive(true);
             gun1.SetActive(false);
       
        }

        else 
            {

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normal, Time.deltaTime * smooth);
          gun1.SetActive(true);

           gun2.SetActive(false);
      

        }
      






    }
}


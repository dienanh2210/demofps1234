using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demogun2 : MonoBehaviour {
    private Animation animation;
    // Use this for initialization
    void Start () {
        animation = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            animation.CrossFade("Fire2");

        }
      /*  if (Input.GetKey(KeyCode.R)) {

            animation.CrossFade("Reload");

        }*/
    }
}

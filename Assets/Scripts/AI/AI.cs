using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public float speed = 3;
    public float obstacleRange = 2;
   
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, speed * Time.deltaTime);

        GetComponent<Animation>().Play("Run");


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {

            if (hit.distance < obstacleRange)
            {

                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }


        }
    }
}

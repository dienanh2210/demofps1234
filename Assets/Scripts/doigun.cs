using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doigun : MonoBehaviour
{

    private GameObject player;

   public int zoom;
  public  int normal = 60;
  public  float smooth = 8;
    private bool zoomedIn = false;
   
    int nn = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
       
    }

    // Update is called once per frame
    void Update()
    {

        fire2();
       

    }

    public void fire2()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            zoomedIn = !zoomedIn;
           

        }
        if (zoomedIn == true)
        {

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);
            seclectGun(1);

        }

        else
        {

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normal, Time.deltaTime * smooth);

            seclectGun(nn);
        }

    }

    void seclectGun(int _gun)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == _gun)
            {
                transform.GetChild(i).gameObject.SetActive(true);

            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }



    }
    

}

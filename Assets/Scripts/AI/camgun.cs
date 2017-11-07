using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camgun : MonoBehaviour {
    public GameObject gun1bullet;
    public GameObject gun2bullet;
    public GameObject panelgun2;
    public GameObject mimap;
    public GameObject canvangun1;
    // Use this for initialization
    void Start () {
        gun1bullet.SetActive(true);
        gun2bullet.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))

        {

            seclectGun(0);
            gun1bullet.SetActive(true);
            gun2bullet.SetActive(false);
            panelgun2.SetActive(false);
           mimap.SetActive(true);
            canvangun1.SetActive(true);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {

           
            seclectGun(1);
            gun1bullet.SetActive(false);
            gun2bullet.SetActive(true);
            
            mimap.SetActive(true);
            canvangun1.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastenemy : MonoBehaviour
{
    GameObject Followter;
    // Use this for initialization
    void Start()
    {
        Vector3 FollowterPosition = gameObject.transform.position;
        FollowterPosition.y += 10;
        Followter = new GameObject("Followter");
        Followter.transform.position = FollowterPosition;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Followter.transform.position, Vector3.down, out hit, 30, 1 << 1))
        {
            gameObject.transform.position = hit.point;
        }
    }
}

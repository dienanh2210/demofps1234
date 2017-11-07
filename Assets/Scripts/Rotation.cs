using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{

    /*public Vector3 RotationAxis;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		this.transform.Rotate (RotationAxis * Time.deltaTime);
	}*/

   
    void Update()
    {

        transform.Rotate(new Vector3(0,0,Time.deltaTime * 10));

    }
}

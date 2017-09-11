using UnityEngine;
using System.Collections;

public class PlayerUnit : Unit
{
		float cameraRotaX = 0f;
		public float maxCamera = 45f;

		// Use this for initialization

		public override void Start ()
		{
				base.Start ();
		}
	
		// Update is called once per frame
		public override void Update ()
		{
            //print (Mathf.Clamp (-10, 1, 3));
            //rotation
            gameObject.transform.Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f);
            //lay goc tao y
            cameraRotaX -= Input.GetAxis("Mouse Y");

            //print (Input.GetAxis ("Mouse Y") + "---");
            //4 9 = -5
            //print ("cameraRotaX:" + cameraRotaX);

            cameraRotaX = Mathf.Clamp(cameraRotaX, -maxCamera, maxCamera);

            Camera.main.transform.forward = transform.forward;
        
        Camera.main.transform.Rotate(cameraRotaX, -45f, 1f);
      

        //movement
        move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			move.Normalize ();//xac dinh huong can di chuyen



                move = transform.TransformDirection(move);//dich chuyen theo huong move
               


                if (Input.GetKey(KeyCode.Space) && control.isGrounded)
                {
                    jump = true;
                }
                running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
				base.Update ();//truyxuat lop ke thua update cua script unit
		}
}

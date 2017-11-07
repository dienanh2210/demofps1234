using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloadfire : MonoBehaviour
{
    private Animation animation;
    public GameObject play;
    private GameObject player;
    public Text point2;
 
    float bullet = 500;
    int damge2 = 35;
  
    void Awake() {
        animation = GetComponent<Animation>();

       
        
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            animation.CrossFade("Fire");

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            play.GetComponent<Gun>().enabled = false;

            int GameBullet = player.GetComponent<gunPlayer>().GameBullet;

            float bullet2 = play.GetComponent<Gun>().bullet2 = 35;
            player.GetComponent<gunPlayer>().PointBullet.text = "Bullet:" + bullet2.ToString();
            //  player.GetComponent<gunPlayer>().PointBullet.text = "Bullet:" + bull.ToString();

            if (bullet2 > 0)
            {

                play.GetComponent<Gun>().enabled = true;

            }



            /* if (bullet==0) {
               //  gameObject.GetComponent<Reloadfire>().enabled=false;
                 play.GetComponent<Gun>().enabled = true;
             }*/



            animation.CrossFade("Reload");

            player.GetComponent<gunPlayer>().GetBullet2(35 - GameBullet);

            player.GetComponent<gunPlayer>().GameBullet = 35;

            /* AudioSource audio = GetComponent<AudioSource>();         
             audio.clip = au;
             audio.Play();*/

        }
        
       

    }
   

}

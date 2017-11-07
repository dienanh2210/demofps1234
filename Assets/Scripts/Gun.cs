using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltraReal.Utilities;
using UltraReal.WeaponSystem;

public class Gun : MonoBehaviour {
   public  int damge = 1;
    int damge2 = 35;
    public float firetime = 0.55f;
    public float lastFireTime = 0;
    public GameObject SmokeOuthit;
    public float bullet2 = 35;
   
    public GameObject lightbullet;
    private Animator anim;
    public AudioClip otherClip;
    public AudioClip stopbullet;
    private Animation animation;

    private GameObject player;
    private GameObject gun;

    //public GameObject Gethit;
    public GameObject par;
    


    
    // Use this for initialization
    void Start () {
        
            UpdateFireTime();
            anim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
       
           
    }
    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

    }

    public void Fire()

    {

        if (Time.time >= lastFireTime + firetime)
        {
            AudioSource audio = GetComponent<AudioSource>();

            // yield return new WaitForSeconds(audio.clip.length);
            audio.clip = otherClip;
            audio.Play();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //  Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log("hit");
                bullet2 -= damge;
                player.GetComponent<gunPlayer>().GetBullet(1);

                if (bullet2 == 0)
                {

                    gameObject.GetComponent<Gun>().enabled = false;

                }
                if (bullet2 > 1)
                {

                    gameObject.GetComponent<Gun>().enabled = true;

                }
                GameObject ab = Instantiate(SmokeOuthit, hit.point, Quaternion.identity);


                // Instantiate(smoke,transform.position,Quaternion.identity);
                if (hit.transform.tag.Equals("Enemy"))
                {

                    Instantiate(lightbullet, transform.position, Quaternion.identity);
                    //  GameObject bc= Instantiate(par,hit.transform.position,Quaternion.identity);
                    GameObject bc = Instantiate(par, hit.point, Quaternion.identity);
                    hit.transform.gameObject.GetComponent<Enemy>().GetHit(damge);
                    //  hit.transform.gameObject.GetComponent<boss>().GetHit(damge);

                    Debug.Log("hitenemy");
                    Destroy(ab);
                }
                if (hit.transform.tag.Equals("Boss"))
                {

                    GameObject a = Instantiate(par, hit.point, Quaternion.identity);
                    // GameObject bc = Instantiate(par, parboss.transform.position, Quaternion.identity);
                    hit.transform.gameObject.GetComponent<boss>().GetHit(damge);

                    Debug.Log("hitenemy");
                    Destroy(ab);
                }
                if (hit.transform.tag.Equals("Bos"))
                {

                    //GameObject bccb = Instantiate(par, hit.transform.position, Quaternion.identity);
                    GameObject bccb = Instantiate(par, hit.point, Quaternion.identity);
                    // GameObject bc = Instantiate(par, parboss2.transform.position, Quaternion.identity);

                    hit.transform.gameObject.GetComponent<Bos>().GetHit(damge);
                    Debug.Log("hitenemy");
                    Destroy(ab);
                }


            }
            UpdateFireTime();
        }

    }
   
}

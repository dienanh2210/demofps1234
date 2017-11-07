using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    private Transform target;
    public float   moveSpeed = 3;
   
    float  rotationSpeed = 3;

    public Transform myTransform;
    public GameObject ragdoll; 
    UnityEngine.AI.NavMeshAgent agent;
    public  bool   isNotDead= true;
    int  health = 5;
    float  damageMin  = 5;
    int damge = 5;
    private GameObject player;

    public Slider sliderenemy;
    public float currentheath = 5;
    int heathenemy = 5;
    // Use this for initialization
    void Awake() {

        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Start () {

       // sliderenemy.maxValue = heathenemy;//=mau mac dinh
        sliderenemy.value = currentheath;//mau hien tai
        sliderenemy.minValue = 0;


    }
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindWithTag("Player").transform;

        

        if (isNotDead)
        {
          

            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);




            var distance = Vector3.Distance(target.position, myTransform.position);
            if (distance < 2.0f)
            {
                GetComponent< Animation > ().Play("Attack");
              //  player.GetComponent<gunPlayer>().heathpanel.SetActive(true);
            }
            else
            {
              
                agent.SetDestination(target.position);
                GetComponent< Animation > ().Play("Run");
              //  player.GetComponent<gunPlayer>().heathpanel.SetActive(false);
               // player.gameObject.GetComponent<gunPlayer>().heathpanel.SetActive(false);
              
            }

        }
    }
    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.tag == "Player")
        {
            // health -= 20;

            // gameObject.GetComponent<gunPlayer>().Gethitplayer(damge);
            player.GetComponent<gunPlayer>().Gethitplayer(damge);

            Debug.Log("hit");
            player.GetComponent<gunPlayer>().heathpanel.SetActive(true);
            Invoke("outpanel", 1);
        }

    }



    public void outpanel() {
        player.gameObject.GetComponent<gunPlayer>().heathpanel.SetActive(false);
    }


    public void GetHit(int damge) {

        currentheath -= damge;
        sliderenemy.value = currentheath;

        
        if (currentheath <= 0)
        {
           // currentheath = 0;

            Destroy(gameObject);

            GameObject a = Instantiate(ragdoll, transform.position, Quaternion.identity);
            Destroy(a, 1.5f);
            //  GetPoint();
            player.GetComponent<gunPlayer>().GetPoint();
        }


    }
    
    
   
}

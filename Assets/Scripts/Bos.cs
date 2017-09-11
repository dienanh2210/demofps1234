using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bos : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 3;
    float rotationSpeed = 3;

    public Transform myTransform;
    public GameObject ragdoll;
    UnityEngine.AI.NavMeshAgent agent;
    public bool isNotDead = true;
    int health = 50;
    float damageMin = 50;
    int damge = 20;
    private GameObject player;

    float MoveRange = 10;


    // Use this for initialization
    void Start()
    {

        //  par.SetActive(false);

        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;

        if (Vector3.Distance(transform.position, player.transform.position) < MoveRange)
        {
            Debug.Log(1);
            //  nav.SetDestination(player.position);
            agent.SetDestination(target.position);
            GetComponent<Animation>().Play("Run");


        }
        else {

            GetComponent<Animation>().Play("idle");
            //agent.SetDestination(target.position);
        }

        if (isNotDead)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            var distance = Vector3.Distance(target.position, myTransform.position);
            if (distance < 2.0f)
            {
                GetComponent<Animation>().Play("Attack");
                //  player.GetComponent<gunPlayer>().heathpanel.SetActive(true);
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
     public Text pointbosscurrent;
     int damgeboss=0;
    int damgecurrentboss = 5;
  public Text restboss;
   
    public void outpanel()
    {
        player.gameObject.GetComponent<gunPlayer>().heathpanel.SetActive(false);
    }

    int current = 1;

    public void GetHit(int damge)
    {

        health -= damge;
        if (health < 0)
        {
            Destroy(gameObject);
            GameObject a = Instantiate(ragdoll, transform.position, Quaternion.identity);
            Destroy(a, 1.5f);           
            player.GetComponent<gunPlayer>().GetPoint();            
            player.GetComponent<gunPlayer>().mission(current);

        }
    }

  /*  public void mission() {

        damgecurrentboss-=1;
        pointbosscurrent.text=""+damgecurrentboss.ToString();

        damgeboss+=1;
        restboss.text = "" + damgeboss.ToString();
    }*/

}

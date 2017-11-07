using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    public bool isNotDead = true;
    public Transform myTransform;
    float rotationSpeed = 3;
   // private Animator anim;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       // anim = GetComponent<Animator>();


      //  anim.SetBool("Run",true);
       // anim.SetBool("Attack", false);

    }
	// Update is called once per frame
	void Update () {
       // if (isNotDead)
      //  {


            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);




            var distance = Vector3.Distance(target.transform.position, myTransform.transform.position);
            if (distance == 2.0f)
            {
                 GetComponent<Animation>().Play("attk2");
                //  player.GetComponent<gunPlayer>().heathpanel.SetActive(true);
              //  anim.SetBool("Attack",true);
            }
            else
            {
              // anim.SetBool("Attack", false);
                agent.SetDestination(target.position);
          //  anim.SetBool("Run", true);
            //  GetComponent<Animation>().Play("run");
            //  player.GetComponent<gunPlayer>().heathpanel.SetActive(false);
            // player.gameObject.GetComponent<gunPlayer>().heathpanel.SetActive(false);

        }

      //  }
    }
}

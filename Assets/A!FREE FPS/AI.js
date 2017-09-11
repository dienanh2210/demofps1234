var target : Transform; 
var moveSpeed = 3; 
var rotationSpeed = 3;

var myTransform : Transform; 
var ragdoll : GameObject;
var agent : UnityEngine.AI.NavMeshAgent;
var isNotDead : boolean = true;
var health : float = 100;
var damageMin : float = 10;
function Awake()
{
    myTransform = transform;
}

function Start()
{
     target = GameObject.FindWithTag("Player").transform; 
      agent = GetComponent.<UnityEngine.AI.NavMeshAgent>();
}

function Update () {
	target = GameObject.FindWithTag("Player").transform;

	if(health < 1){
	
		isNotDead = false;
        
        
        Instantiate(ragdoll, myTransform.position, myTransform.rotation);
        
	}
	
	if(isNotDead){
	

	    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
	    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
	


	    
	    var distance = Vector3.Distance(target.position, myTransform.position);
	    if (distance < 2.0f) {
	        GetComponent.<Animation>().Play("Attack");
	    }
	    else{   

	   		agent.SetDestination(target.position);
	   		GetComponent.<Animation>().Play("Run");
	    }

	}
}


 function OnTriggerEnter(collider : Collider)
 {
     if(collider.tag == "impact")
     {
            health -= 20;     
     }
 }



function ApplyDamage(dmg : float){

	health -= 20;

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	private NavMeshAgent agent;
    private Animator an;
    public Transform player;
    public Transform bullet;
    private Vector3 direction;
    public float angleView = 90;
    private float angle;
    private float fieldOfView;
	public Transform enemy;
	public float damage_dealt;
    public float distanceToSee;
    public Transform[] points;
    private int destPoint;
    private float delayTime;
    public float startDelayTime;
    private float timeCount = 1f;
    EnemyShooting shoot;
	EnemyHealth health;
    public AudioClip death;

    // Use this for initialization
    void Start () {
        an = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent> ();
		shoot = GetComponent<EnemyShooting>();
		health = GetComponent<EnemyHealth> ();

        delayTime = startDelayTime;
        agent.autoBraking = false;

    }
	
	// Update is called once per framew
	void Update () {

		EnemyVision ();

        if (!agent.pathPending && agent.remainingDistance < 1f) 
		{
			an.SetInteger ("Alien", 0);
			if (delayTime <= 0) {
				
				delayTime = startDelayTime;
				EnemyPatrol ();

			    
			} else 
			{
				
				delayTime -= Time.deltaTime;

			}

		}

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().currentHealth <= 0)
        {
           
            shoot.playerSpotted = false;
         
        
        }


    }

    public void EnemyVision()
    {

        //CODE FOR DETERMINING POSITION OF PLAYER FROM THE ENEMY AND ALSO DETERMINING THE DISTANCE BETWEEN THE PLAYER AND ENEMY
        direction = Vector3.down + player.transform.position - transform.position;

        fieldOfView = Vector3.Distance(player.position, transform.position);

        angle = Vector3.Angle(transform.forward, direction);

        
        //CODE FOR DETERMINING IF THE PLAYER IS WITHIN VIEW ANGLE OF THE ENEMY AND IF IT IS THEN FOLLOW PLAYER
        if (angle <= angleView && fieldOfView <= distanceToSee)
        {
            EnemyLogic();
            
        }
       

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.magnitude == 0f)
            {

                an.SetInteger("Alien", 0);
                
            }
        }
    }

    public void EnemyPatrol()
    {

        agent.stoppingDistance = 1f;
			// Set the agent to go to the currently selected destination.
			agent.destination = points [destPoint].position;
			// Choose the next point in the array as the destination,
			destPoint = Random.Range (0, points.Length);
			agent.speed = 5;
			an.SetInteger("Alien", 1);

    }


    public void EnemyLogic()
    {

        shoot.playerSpotted = true;
        agent.SetDestination(player.transform.position);
        //transform.LookAt(Vector3.down + player.transform.position);
        agent.speed = 11;
        an.SetInteger("Alien", 2);
        agent.stoppingDistance = 11f;
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeCount);

    }
    
	private void OnTriggerStay(Collider player)
	{
		if (player.gameObject.tag == "Player") 
		{

            EnemyLogic();
        }

	}

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Bullet")
        {

            EnemyLogic();
        }

    }

    private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Bullet") 
		{
			health.Damage (damage_dealt);
            EnemyLogic();
            if(health.enemyHealth <= 0.0f)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                agent.speed = 0f;
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


	public float enemyHealth = 100f;
    private Animator an;

    

    void Start()
    {

        an = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
        
		if (enemyHealth <= 0.0f)
		{
        
            Invoke("EnemyDeath", 4.5f);
            an.SetTrigger("AlienDeath");
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<EnemyShooting>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
      
        }

	}

	public void Damage(float damage_dealt)
	{
        enemyHealth = enemyHealth - damage_dealt;
	}

	public float GetHealth()
	{
		return enemyHealth;
	}

    public void EnemyDeath()
    {
        Object.Destroy(gameObject);
    }
}

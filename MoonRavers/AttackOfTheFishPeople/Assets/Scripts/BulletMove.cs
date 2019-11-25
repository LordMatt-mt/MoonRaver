using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 20f;
	public GameObject bulletImpact;


	void Start()
	{

		rb = GetComponent<Rigidbody> ();

	}

	void FixedUpdate() {
		
		rb.velocity = transform.forward * speed;

		StartCoroutine ("DeactivateBullet");
	}
	


	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player") {


			gameObject.SetActive(false);
			GameObject impact = Instantiate (bulletImpact, gameObject.transform.position, Quaternion.identity);
			Destroy (impact, 1f);

		}
	}
		
	IEnumerator DeactivateBullet()
	{
		yield return new WaitForSeconds (2f);
		gameObject.SetActive (false);
	}
}

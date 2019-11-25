using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

		public Transform enemyFirePoint;
		private int enemyMaxAmmo = 15;
		private int ammo = 15;
		private bool delay = false;
		public bool playerSpotted = false;
		private bool reload = false;
        public AudioClip enemyBlaster;

		void Update()
		{

			if (playerSpotted) 
			{

				if (ammo > 0)
				{
					if (!delay)
					{
						FireGun();
						StartCoroutine(Delay());
						ammo -= 1;
						delay = true;
						print ("bullet: " + ammo);
                        AudioSource.PlayClipAtPoint(enemyBlaster, transform.position);
					}
				}

			}

			if (ammo <= 0) 
			{
				StartCoroutine(Reload());
				print ("reload");
				reload = true;
			}


		}

		public void FireGun()
		{
			
				
				GameObject laser = ObjectPool.sharedInstance.GetPooledObject();
				if (laser != null)
				{

					laser.transform.position = enemyFirePoint.transform.position;
					laser.transform.rotation = enemyFirePoint.transform.rotation;
					laser.SetActive(true);

				}


		}
			

		IEnumerator Delay()
		{
			yield return new WaitForSeconds(1.1f);
			delay = false;
		}

		IEnumerator Reload()
		{
			yield return new WaitForSeconds(3f);
			ammo = enemyMaxAmmo;
			reload = false;
		}

}

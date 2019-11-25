using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
	public Text magazine;
	public Text noAmmo;
    private int maxAmmo = 100;
    private int stockAmmo = 30;
    private int magAmmo = 15;
    private int currAmmo = 15;
    private bool isReloading = false;
    private Animator an;
    public bool fullyLoaded = false;
    public AudioClip blaster;

    // Use this for initialization
    void Start () {
        an = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        fullyLoaded = stockAmmo == maxAmmo;

        magazine.text = currAmmo+"/"+stockAmmo;

        if (!isReloading)
        {

            if ((Input.GetMouseButtonDown(0))&&(currAmmo>0))
            {

                AudioSource.PlayClipAtPoint(blaster, transform.position);

                GameObject laser = ObjectPool.sharedInstance.GetPooledObject();
                if (laser != null)
                {

                    laser.transform.position = firePoint.transform.position;
                    laser.transform.rotation = firePoint.transform.rotation;
                    laser.SetActive(true);

                }

                currAmmo -= 1;

                if ((currAmmo <= 0)&&(stockAmmo <= 0))
                {
                    noAmmo.gameObject.SetActive(true);
                }
            }


            if (stockAmmo > 0)
            {
                if ((currAmmo <= 0) || ((currAmmo <= magAmmo) && ((Input.GetKey("r"))&&(currAmmo<magAmmo))))
                {
                    StartCoroutine(Reloading());
                    isReloading = true;
                    an.SetBool("Reload", true);
                }
            }

            

        }

    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(2f);
        
        if (stockAmmo >= 0)
        {            
            stockAmmo += currAmmo;
            if (stockAmmo >= magAmmo)
                currAmmo = magAmmo;
            else
                currAmmo = stockAmmo;
            stockAmmo -= currAmmo;

        }
        isReloading = false;
        an.SetBool("Reload", false);
    }

    public void AddAmmo(int amount)
    {
        noAmmo.gameObject.SetActive(false);
        stockAmmo = (stockAmmo + amount);
        if (stockAmmo > maxAmmo) stockAmmo = maxAmmo;
        fullyLoaded = stockAmmo == maxAmmo;
    }

}

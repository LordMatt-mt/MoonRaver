using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject door;
    public GameObject theLads;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            theLads.SetActive(true);
            Destroy(door);
            this.gameObject.SetActive(false);
        }
    }
}

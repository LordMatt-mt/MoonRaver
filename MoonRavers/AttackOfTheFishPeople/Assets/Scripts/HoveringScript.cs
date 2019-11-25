using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringScript : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
        transform.position = this.transform.position + Vector3.up * 0.005f * Mathf.Cos(Time.time);
    }
}

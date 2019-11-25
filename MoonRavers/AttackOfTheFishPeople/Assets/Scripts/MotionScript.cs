using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour {

    public float sway;
    public float speed;

    void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.up * sway * Mathf.Cos(Time.time * speed);
    }
}

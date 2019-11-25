using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    
    //private float clampCamera;
	public float mouseSpeed;
	private float camClamp;
	public Transform body;
    public Transform head;
    private Vector3 cameraEuler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float MouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
		float MouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

		camClamp += MouseY;

		if (camClamp > 85.0f) 
		{
			camClamp = 85.0f;
			MouseY = 0.0f;
            ClampCameraToEulerRotation(260.0f);
	
		} 
		else if (camClamp < -70.0f)
		{
			camClamp = -70.0f;
			MouseY = 0.0f;
            ClampCameraToEulerRotation(70.0f);
        }

		head.Rotate(Vector3.left, MouseY);
		body.Rotate (Vector3.up , MouseX);
    

    }

    void ClampCameraToEulerRotation(float val)
    {
        cameraEuler = transform.eulerAngles;
        cameraEuler.x = val;
        transform.eulerAngles = cameraEuler;

    }
}

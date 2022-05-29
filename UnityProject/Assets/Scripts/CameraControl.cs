using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public Vector3 offset = new Vector3(0, 4.14f, -4.4f);
	public float RotationSpeed;
	[Range(0.01f, 1.0f)]
	public float smoothFactor = 0.5f;

	public float height;
	public float zoomSpeed = 4f;
	public float currentZoom = 1;
	public float minZoom = .5f;
	public float maxZoom = 1.5f;
	//public float yawSpeed = 80f;
	//private float currentYaw = 0f;

	// Use this for initialization
	void Start () {
		//offset = transform.position - target.position;
		//move the camera behind the players position
		transform.position = target.position + offset;
	}
	
	// Update is called once per frame
	void Update () {
		currentZoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp (currentZoom, minZoom, maxZoom);

		//currentYaw += (Input.GetAxis ("Horizontal") * yawSpeed * Time.deltaTime);
	}

	void LateUpdate()
	{
		//if i click the right mouse button
		//if (Input.GetMouseButton (1))
		//{
			//get the rotation of the camera around the Y axis with the angle created by the mouse X axis
		//	Quaternion camTurnAngle = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * RotationSpeed, Vector3.up);
			//update the offset of the camera
			//offset = camTurnAngle * offset;
		//}

		Vector3 newPos = target.position + offset * currentZoom;
		//Slowly move the camera towards the players position minus the offset
		transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor);
		//make camera look at the player
		transform.LookAt (target.position + Vector3.up * height);

		//transform.position = target.position - offset * currentZoom;
		//transform.LookAt (target.position + Vector3.up * height);
		//transform.RotateAround (target.position, Vector3.up, currentYaw);
		

	}

}

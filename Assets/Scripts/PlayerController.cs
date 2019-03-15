using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 18;

	public float turnSpeed = 60;
	public Vector3 rot;
	private float rotY = 0.0f;
	private float rotX = 0.0f;

 
	private Rigidbody rig;

	// Use this for initialization
	void Start ()
	{
		rot = transform.localRotation.eulerAngles;
 		rig = GetComponent<Rigidbody>();
		rotY = rot.y;
		rotX = rot.x;

	}

	// Update is called once per frame
	void Update () 
	{


		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		float rStickX = Input.GetAxis("X360_RStickX");
		//float rStickY = -Input.GetAxis("X360_RStickY");


		Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);

		rig.MovePosition(transform.position + movement);

		Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

		//rotate right stick analog
		transform.Rotate(new Vector3(0, rStickX, 0), turnSpeed * Time.deltaTime);
 
		//Quaternion rotation2 = Quaternion.Euler(new Vector3(rStickY, 0, 0) * turnSpeed * Time.deltaTime);

		//transform.Rotate(new Vector3(rStickY, 0, 0), turnSpeed * Time.deltaTime); 

	}
}
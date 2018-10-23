using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float min_x, max_x, min_z, max_z, forceMag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < min_x)
		{
			this.GetComponent<Rigidbody>().AddForce(forceMag,0.0f,0.0f);
		}
		else if(transform.position.x > max_x)
		{
			this.GetComponent<Rigidbody>().AddForce(-forceMag,0.0f,0.0f);
		}
		else if(transform.position.z < min_z)
		{
			this.GetComponent<Rigidbody>().AddForce(0.0f,0.0f,forceMag);
		}
		else if(transform.position.z > max_z)
		{
			this.GetComponent<Rigidbody>().AddForce(0.0f,0.0f,-forceMag);
		}
	}
}

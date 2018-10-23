using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {


	public Vector3 ballPos, spawnPos, lastPosition, dir;
	public GameObject ball;
	// Use this for initialization
	void Start () {
		ballPos = ball.transform.position;
        spawnPos = transform.position;
        lastPosition = spawnPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
            transform.position = spawnPos;
			ball.transform.position = ballPos;
		}
        dir = transform.position - lastPosition;
        lastPosition = transform.position;
	}

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball"){
            col.gameObject.GetComponent<Rigidbody>().AddForce(dir*5000);
        }
    }
}

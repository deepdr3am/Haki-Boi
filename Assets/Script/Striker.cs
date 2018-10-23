using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{

    public float mX;
    public float mY;

    public bool isWall = false;
    public float speed;
    public float max_x = -2.8f, max_z = -5.6f, min_x = -4.4f, min_z = -7.6f;
    public Vector3 ballPos, spawnPos, lastPosition, dir;
	public GameObject ball;

    

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
		ballPos = ball.transform.position;
        spawnPos = transform.position;
        lastPosition = spawnPos;
    }

    void FixedUpdate()
    {
        mX = Input.GetAxis("Mouse X");
        mY = Input.GetAxis("Mouse Y");
        if (!isWall)
        {
            float move_x = mX * Time.deltaTime * speed;
            float move_z = mY * Time.deltaTime * speed;

            if ((transform.position.x + move_x > min_x && transform.position.x + move_x < max_x) &&
             (transform.position.z + move_z > min_z && transform.position.z + move_z < max_z))
            {
				print("Move");
                transform.Translate(-move_z, 0, move_x);
            }
            else if(transform.position.x + move_x < min_x)
            {
				this.GetComponent<Rigidbody>().AddForce(10000.0f,0.0f,0.0f);
            }
			else if(transform.position.x + move_x > max_x)
            {
				this.GetComponent<Rigidbody>().AddForce(-10000.0f,0.0f,0.0f);
            }
			else if(transform.position.z + move_z < min_z)
            {
				this.GetComponent<Rigidbody>().AddForce(0.0f,0.0f,10000.0f);
            }
			else if(transform.position.z + move_z > max_z)
            {
				this.GetComponent<Rigidbody>().AddForce(0.0f,0.0f,-10000.0f);
            }
        }
    }

    // Update is called once per frame
    // X: -1.5 -2.6 Z: -7.4 , -8.7
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            transform.position = spawnPos;
			ball.transform.position = ballPos;
		}
        dir = transform.position - lastPosition;
        lastPosition = transform.position;

        /* mX = Input.GetAxis("Mouse X");
		mY = Input.GetAxis("Mouse Y");
		if (!isWall && isInside){
			mX = Mathf.Min(mX, 5);
			mY = Mathf.Min(mY,5);
			float move_x = mX * Time.deltaTime * speed;
			float move_y = mY * Time.deltaTime * speed;
			//if((transform.position.x + move_x > min_x && transform.position.x + move_x < max_x) &&
			 //(transform.position.z + move_y > min_z && transform.position.z + move_y < max_z))
				transform.Translate(mX * Time.deltaTime * speed, 0, mY * Time.deltaTime * speed);
		}*/
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "wall")
        {
            isWall = true;
        }
        else
        {
            isWall = false;
        }
        if (col.gameObject.tag == "ball"){
            col.gameObject.GetComponent<Rigidbody>().AddForce(dir*5000);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "wall")
        {
            isWall = false;
        }
    }

}

using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public float movement=5.0f;
	Vector3 directionRun,left,right;
	// Use this for initialization
	void Start () {
		directionRun = new Vector3 (0,0,0);
		right = GameObject.Find ("RightShoe").transform.position;
		left=GameObject.Find ("LeftShoe").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float rotateLR = Input.GetAxis ("Mouse X");
		transform.Rotate (0,rotateLR,0);
		float forwardspeed = Input.GetAxis ("Vertical")*movement;
		float sidespeed = Input.GetAxis ("Horizontal") * movement;
		Vector3 speed = new Vector3 (sidespeed, 0, forwardspeed);
		speed = transform.rotation * speed;
		CharacterController cc = GetComponent<CharacterController>();
		//cc.SimpleMove (speed);
		//testing-------------------------------
		right = GameObject.Find ("RightShoe").transform.position;
		left=GameObject.Find ("LeftShoe").transform.position;
		if (Vector3.Distance (left, right) > 1f)
						directionRun = right - left;//directionRun=new Vector3(0,0,Input.GetAxis ("Vertical")*movement);
		else
						directionRun = new Vector3 (0, 0, 0);
		//directionRun.y=0;
		cc.SimpleMove (directionRun);
		//testing-------------------------------

	}
}

using UnityEngine;
using System.Collections;


public class walking : MonoBehaviour {
	public float TravelSpeed = 1.0f;
	private GameObject leftfoot;
	private GameObject rightfoot;
	private GameObject Head;
	private bool stepping = false;
	
	void Start () {
		leftfoot = GameObject.Find("LeftShoe");
		rightfoot = GameObject.Find("RightShoe");
		Head = GameObject.Find("HMD");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!stepping){
			if(leftfoot.transform.position.y > 0.3f||rightfoot.transform.position.y > 0.3f)	{
				stepping = true;
				
			}
		}
		else{
			if(leftfoot.transform.position.y < 0.3f||rightfoot.transform.position.y < 0.3f){
				stepping = false;
			}
		}
		if(stepping){
			
			Vector3 movement = new Vector3(0,0,0);
			movement.x = Head.transform.forward.x;
			movement.z = Head.transform.forward.z;
			movement.Normalize();
			CommonVariables.mappedPosition += movement * TravelSpeed * Time.deltaTime;
		}
	}
}

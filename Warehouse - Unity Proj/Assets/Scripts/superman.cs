using UnityEngine;
using System.Collections;

public class superman : MonoBehaviour {

	public float TravelSpeed = 0.5f;
	public float RotationSpeed = 10f;
	private GameObject left;
	private GameObject right;
	private GameObject Head;
	private float ratio1;
	private float ratio2;
	
	// Use this for initialization
	void Start () {
		left = GameObject.Find("LeftWiimote");
		right = GameObject.Find("RightWiimote");
		Head = GameObject.Find("HMD");
	}
	
	// Update is called once per frame
	void Update () {


		if (left.transform.position.y > 1.5f && right.transform.position.y > 1.5f) {

			ratio1 = 2.5f-right.transform.position.y;
			ratio1 = 10f/ratio1;
			//Vector3 movement = new Vector3(0,0,0);
			//movement.x = Head.transform.forward.x;
			//movement.z = Head.transform.forward.z;
			//movement.Normalize();
			CommonVariables.mappedPosition += transform.forward* TravelSpeed * ratio1 *Time.deltaTime;
			//CommonVariables.mappedPosition += transform.forward * TravelSpeed *ratio1 * Time.deltaTime;
		}

		if (left.transform.position.y > 0.5f && right.transform.position.y > 0.5f&&left.transform.position.y < 0.9f && right.transform.position.y < 0.9f) {
			ratio2 = 1.0f-right.transform.position.y;
			ratio2 = ratio2/0.1f;
			CommonVariables.mappedPosition -= transform.forward * TravelSpeed * ratio2* Time.deltaTime;
		}

		if (left.transform.position.y > 1.5f && right.transform.position.y < 1.5f && right.transform.position.y > 1.1f) {
			CommonVariables.mappedRotation.y -= RotationSpeed * Time.deltaTime;
		}

		if (right.transform.position.y > 1.5f && left.transform.position.y < 1.5f && left.transform.position.y > 1.1f) {
			CommonVariables.mappedRotation.y += RotationSpeed * Time.deltaTime;
		}
}
}


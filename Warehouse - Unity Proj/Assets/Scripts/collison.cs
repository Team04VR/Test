using UnityEngine;
using System.Collections;

public class collison : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		Debug.Log ("collision!");
	//	if(col.gameObject.name=="PhysicalSpace")GameObject.Find("PhysicalSpace").GetComponent<Steering>().TravelSpeed=0f;
	}
}

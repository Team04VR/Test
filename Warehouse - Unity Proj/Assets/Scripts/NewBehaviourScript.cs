using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour {
	public string RightWiimote = "RightWiimote";
	public string LeftWiimote = "LeftWiimote";
	public float RotationSpeed = 0.01f;
	//Create a new Line render and sets up the first two points
	private ArrayList taglist;
	private ArrayList SelectObjLst;
	LineRenderer myLine;

	Vector3 leftPosition;

	private GameObject cube;
	void Start () {
		//Create our line, we set its points to zero because we are only initializing it.

		GameObject go = new GameObject ();
		go.name = "MyLineRenderer";
		myLine =go.AddComponent("LineRenderer")as LineRenderer ;		
		//Set the number of points
		myLine.SetVertexCount(2);		
		//Use world space
		myLine.useWorldSpace = true;		
		//Sets the positions of the first two points
		myLine.SetPosition(0,Vector3.zero);
		myLine.SetPosition(1,Vector3.zero);

		//isSelect = true;
		SelectObjLst = new ArrayList();
		taglist = new ArrayList ();
		leftPosition = InputBroker.GetPosition(LeftWiimote);
		//leftRotation = InputBroker.GetRotation(LeftWiimote);
	}
	// Update is called once per frame
	void Update () {
				//virtual world
				Vector3 origin = transform.position + (transform.forward * 0.3f);
				Vector3 direction = transform.forward;
				RaycastHit hit;


		if (Physics.Raycast (origin, direction, out hit)) {
				Debug.Log ("we hit something  " + hit.collider.gameObject.name);
						//Debug.DrawLine(origin, hit.point,Color.red);
				myLine.SetPosition (0, origin);
				myLine.SetPosition (1, hit.point);
				myLine.SetColors (Color.red, Color.red);
				myLine.SetWidth (0.01f, 0.01f);
				if (InputBroker.GetKeyDown (RightWiimote + ":A")) {
						hit.collider.gameObject.tag = "Player";
				        taglist.Add(hit.collider.gameObject);
				}
				if (InputBroker.GetKeyDown (RightWiimote + ":Up")) {

						if (hit.collider.gameObject.tag == "Player")
								hit.collider.gameObject.layer = 2;
						}
			   if (InputBroker.GetKeyDown (RightWiimote + ":Down")) {
				
				if(taglist.Count != 0)
				{
					foreach(GameObject obj in taglist)
					{
						obj.tag = "Untagged";
						obj.layer = 0;
					}
				}
			    }
			   if(InputBroker.GetKeyPress(RightWiimote + ":B"))  //select
			    {
					SelectObjLst.Add(hit.collider.gameObject);
							
				hit.collider.gameObject.renderer.material.color = Color.red;
				

			    }
			  if(InputBroker.GetKeyPress(RightWiimote + ":One")) {  //remove one 
				SelectObjLst.Remove(hit.collider.gameObject);
				hit.collider.gameObject.renderer.material.SetColor("_Color",Color.white);
			  }
			
			  if(InputBroker.GetKeyPress(RightWiimote + ":Two")) {  //remove all, restart
				if(SelectObjLst.Count != 0)
				{
					foreach(GameObject obj in SelectObjLst)
						obj.renderer.material.SetColor("_Color",Color.white);
				}
				if(taglist.Count != 0)
				{
					foreach(GameObject obj in taglist)
					{
						obj.tag = "Untagged";
						obj.layer = 0;
					}
				}
				SelectObjLst.Clear();
				taglist.Clear();
			  }

			
				} 
		 else {
						Debug.Log ("we did not");
						myLine.SetPosition (0, origin);
						myLine.SetPosition (1, origin);
						myLine.SetColors (Color.red, Color.red);
						myLine.SetWidth (0.01f, 0.01f);
				}

		if(InputBroker.GetKeyDown(LeftWiimote + ":A"))
			MakeRotation();
		
		if(InputBroker.GetKeyDown(LeftWiimote + ":B"))
			changeColor();
		if(InputBroker.GetKeyDown(LeftWiimote + ":Left")) {
			CommonVariables.mappedRotation.y -= RotationSpeed * Time.deltaTime;
		}
		
		// Right button rotates the virtual world right (heading only) 
		if(InputBroker.GetKeyDown(LeftWiimote + ":Right")) {
			CommonVariables.mappedRotation.y += RotationSpeed * Time.deltaTime;
		}
		}

	void MakeRotation()
	{
		Vector3 current = InputBroker.GetPosition(LeftWiimote);
		
		float xChange = current.x - leftPosition.x;
		float yChange = current.y - leftPosition.y;
		float zChange = current.z - leftPosition.z;
		foreach(GameObject obj in SelectObjLst)
		{
			if(xChange > 0)//may be work??
				obj.transform.RotateAround(obj.transform.position, obj.transform.forward, -10);
			else if(xChange < 0)//may be work??
				obj.transform.RotateAround(obj.transform.position, obj.transform.forward, 10);
			
			if(yChange > 0)
				obj.transform.RotateAround(obj.transform.position, obj.transform.up, -10);
			else if(yChange < 0)
				obj.transform.RotateAround(obj.transform.position, obj.transform.up, 10);
			
			if(zChange > 0)
				obj.transform.RotateAround(obj.transform.position, obj.transform.right, 10);
			else if(zChange < 0)
				obj.transform.RotateAround(obj.transform.position, obj.transform.right, -10);
		}
		
		leftPosition = current;
	}
	
	void changeColor()
	{
		if(SelectObjLst.Count != 0)
		{
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			// apply it on current object's material

			foreach(GameObject obj in SelectObjLst)
				obj.renderer.material.SetColor("_Color",newColor);
		}
	}
}	
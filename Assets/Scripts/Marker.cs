using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO better visual for already visited sectors
public class Marker : MonoBehaviour {


	private Vector2 position;
	private Sector sector;
	private bool visited = false;

	private UIController UIController;

	string infotext = "";

	void OnGUI(){
		GUI.Label (new Rect (Input.mousePosition.x+15, Screen.height - Input.mousePosition.y, infotext.Length * 10, 20),
			infotext);
	}

	void OnMouseEnter(){		
		if (!visited && !sector.Equals(Sector.Start)) {
			infotext = sector.ToString ();
		} else {
			infotext = "Already visited";
		}
	}

	void OnMouseExit(){
		infotext = "";
	}

	void OnMouseDown(){
		if (!visited && !sector.Equals(Sector.Start)) {
			UIController = GameObject.FindGameObjectWithTag ("UIController").GetComponent<UIController> ();
			visited = true;
			this.UIController.requestNewMap (sector);
		}
	}

	public Sector getSector(){
		return sector;
	}

	public void setSector (Sector s){
		this.sector = s;
	}

	public Vector2 getPosition(){
		return position;
	}
	public void setPosition(Vector2 pos){
		this.position = pos;
	}
		
}

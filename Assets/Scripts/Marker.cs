using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {


	private Vector2 position;
	private Sector sector;

	private GameObject UIController;

	string infotext = "";

	void OnGUI(){
		GUI.Label (new Rect (Input.mousePosition.x+15, Screen.height - Input.mousePosition.y, infotext.Length * 10, 20),
			infotext);
	}

	void OnMouseEnter(){
		infotext = sector.ToString ();
	}

	void OnMouseExit(){
		infotext = "";
	}

	void OnMouseDown(){
		UIController = GameObject.FindGameObjectWithTag ("UIController");
		UIController.SendMessage ("requestNewMap",gameObject.name);
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

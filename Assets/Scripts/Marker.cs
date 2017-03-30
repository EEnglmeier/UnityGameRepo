using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

	public GameObject UIController;

	void OnMouseDown(){
		UIController = GameObject.FindGameObjectWithTag ("UIController");
		UIController.SendMessage ("requestNewMap",gameObject.name);
	}
		
}

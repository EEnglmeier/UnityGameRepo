using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Button fireButton;
	public Button sailButton;
	public GameController GC;

	private float fireCooldown = 1.0f;
	private bool cooldown = false;

	private ModularPanel modularPanel;


	// Use this for initialization
	void Start () {
		modularPanel = ModularPanel.getInstance ();
		showStartMessage ();
		addButtonListeners ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addButtonListeners(){
		fireButton.onClick.AddListener(() => {requestFire();});
		sailButton.onClick.AddListener(() => {requestSail();});
	}

	public void requestFire(){
		if (!cooldown) {
			GC.playerFire ();
			cooldown = true;
			Invoke ("resetCD", fireCooldown);
		}
	}

	private void showStartMessage(){
		modularPanel.choice ("Do you want to start the game?","Yes, please!", "No!", "I want to die!");
	}

	public void requestNewMap(string str){
		GC.randomNewMap ();
	}

	public void requestSail(){
		GC.setSail ();
	}

	public void showSetSailButton(){
		sailButton.gameObject.SetActive (true);
	}

	public void hideSetSailButton(){
		sailButton.gameObject.SetActive (false);
	}

	private void resetCD(){
		cooldown = false;
	}

}





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

	public ModularPanel modularPanel;

	void Awake(){
		modularPanel = ModularPanel.getInstance ();
	}

	void Start () {
		addButtonListeners ();
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

	public void showMessage(GameEvent gv){
		modularPanel.choice (gv);
	}

	public void requestNewMap(Sector sector){
		GC.randomNewMap (sector);
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





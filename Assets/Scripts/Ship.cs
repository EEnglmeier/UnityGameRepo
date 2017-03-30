using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	private GameObject GameController;
	private GameController GC;
	private float hullHitPoints = 20.0f;
	private float damageTaken = 0.0f;

	void OnCollisionEnter2D(Collision2D coll){
		//TODO probably needs better way to get the damage taken
		this.damageTaken = GC.playerDamage;
		hullHitPoints -= this.damageTaken;
		Destroy (coll.gameObject);
	}

	// Use this for initialization
	void Start () {
		GameController =  GameObject.FindWithTag ("GameController");
		GC = GameController.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hullHitPoints <= 0.0f) {
			Debug.Log ("Dead");
			GC.SendMessage ("destroyShip", transform.gameObject);
		}

	}
		
	public float getHullHitPoins(){
		return hullHitPoints;
	}
}

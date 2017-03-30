using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public UIController UIController;

	public GameObject enemyShipPrefab;
	public GameObject mapPrefab;
	public GameObject cannonBallPrefab;

	public GameObject playerShip;
	private GameObject Map;
	private GameObject enemyShip;

	public float playerDamage;

	private float cannonballSpeed = 10.0f;
	private float sailSpeed = 0.5f;
	private Vector3 sailTarget;

	private bool setSailPhase = false;
	private bool gamePhase = true;

	private readonly Vector3 playerPosition = new Vector3 (-7.5f,0.0f,0.0f);

	// Use this for initialization
	void Start () {
		instantiateEnemy ();
	}

	// Update is called once per frame
	void Update () {
		if (setSailPhase) {
			playerShip.transform.position = Vector3.Lerp (playerShip.transform.position, sailTarget, Time.deltaTime * sailSpeed);
			if (playerShip.transform.position.y >= sailTarget.y-7) {
				gamePhase = true;
				setSailPhase = false;
				showMap ();
			}
		}
	}

	public void playerFire(){
		fire (playerShip, playerDamage);
	}

	public void fire(GameObject ShipToFire, float dmg){
		if (gamePhase) {
			//TODO offset depends on ship position
			float posX = ShipToFire.transform.position.x + 1.5f;

			Rigidbody2D cannonBallClone = Instantiate (cannonBallPrefab, new Vector3 (posX, ShipToFire.transform.position.y, ShipToFire.transform.position.z), transform.rotation).GetComponent<Rigidbody2D> ();
			cannonBallClone.velocity = cannonBallClone.transform.forward * cannonballSpeed;
			cannonBallClone.AddForce (new Vector2 (500f, 0.0f));
		}
	}


	public void destroyShip(GameObject shipToDestroy){
		if (checkEnemyDestroyed (shipToDestroy)) {
			this.UIController.showSetSailButton ();
		}
		Destroy (shipToDestroy);
	}

	private void showMap(){
		this.UIController.hideSetSailButton ();
		Map = Instantiate(mapPrefab, new Vector3(0, 0, 0), transform.rotation);
	}

	// loads a random new map and new events after defeating an enemy
	public void randomNewMap(){
		resetPlayerPosition ();
		instantiateEnemy ();
		Destroy (Map);
	}

	public void setSail(){
		sailTarget = new Vector3 (playerShip.transform.position.x,15.0f,playerShip.transform.position.z);
		setSailPhase = true;
		gamePhase = false;
	}

	private void instantiateEnemy(){
		enemyShip = Instantiate (enemyShipPrefab, new Vector3 (7.2f, 0.05f, 0.0f), transform.rotation);
	}

	private bool checkEnemyDestroyed(GameObject destroyedShip){
		return enemyShip.Equals(destroyedShip) ?  true :  false;
	}

	private void resetPlayerPosition(){
		playerShip.transform.position = playerPosition;
	}
}

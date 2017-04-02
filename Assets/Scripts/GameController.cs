using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sector{Start, Unknown, Pirate, Final};
public enum Level {One, Two, Three, Four, Five, Six, Seven, Eight};

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

	private EventProcessor eventProcessor;
	private Level level = Level.One;
	private Sector sector = Sector.Start;

	private readonly Vector3 playerPosition = new Vector3 (-7.5f,0.0f,0.0f);

	// Use this for initialization
	void Start () {
		eventProcessor = new EventProcessor ();
		initializeNewEvent (eventProcessor.getNextEvent(sector,level));
	}
	/**
	* receives the user selected option from the Modular Panel. Always regarding the current GameObject.
	* Possible outcomes:
	* 
	* 10 = SPAWN ENEMEY
	* 11 = GAMEOVER
	* 0 = Get next Dialogue with id=0
	* 1 = Get next Dialogue with id=1
	* 2 = Get next Dialogue with id=2
	* 3 = Get next Dialogue with id=3
	* 4 = ...
	**/
	public void triggerResponse(SelectedChoice choice){
		switch (choice) {
		case SelectedChoice.ChoiceOne:
			startNewEvent(eventProcessor.currentGameEvent.getResponseKeyOne ());
			break;
		case SelectedChoice.ChoiceTwo:
			startNewEvent(eventProcessor.currentGameEvent.getResponseKeyTwo ());
			break;
		case SelectedChoice.ChoiceThree:
			startNewEvent(eventProcessor.currentGameEvent.getResponseKeyThree());
			break;
		default:
			Debug.LogError("No possible Choice Selected"); 
			break;
		}
	}

	private void startNewEvent(int choiceFromXML){
		switch (choiceFromXML) {
		case 11:
			gameOver ();
			break;
		case 10: 
			instantiateEnemy ();
			break;
		default:
			initializeNewEvent (eventProcessor.getNextDialogueOption (choiceFromXML));
			break;
		}
	}

	private void gameOver(){
		Debug.Log ("GAME OVER");
	}

	public void initializeNewEvent(GameEvent gameEvent){
		UIController.showMessage (gameEvent);
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

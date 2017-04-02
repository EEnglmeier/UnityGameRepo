using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public enum SelectedChoice {ChoiceOne, ChoiceTwo, ChoiceThree};

public class ModularPanel : MonoBehaviour {

	public Text question;
	public Image iconImage;
	public Text choiceOne;
	public Text choiceTwo;
	public Text choiceThree;
	public GameObject modularPanelObject;

	private static ModularPanel modularPanel;

	private GameController GC;

	void Awake(){
		this.GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		EventTrigger choiceOneTrigger = this.choiceOne.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener ((data) => {  
			OnPointerClickDelegateChoiceOne ((PointerEventData)data); });
		choiceOneTrigger.triggers.Add (entry);

		EventTrigger choiceTwoTrigger = this.choiceTwo.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entryTwo = new EventTrigger.Entry ();
		entryTwo.eventID = EventTriggerType.PointerClick;
		entryTwo.callback.AddListener ((data) => { 
			OnPointerClickDelegateChoiceTwo ((PointerEventData)data); });
		choiceTwoTrigger.triggers.Add (entryTwo);

		EventTrigger choiceThreeTrigger = this.choiceThree.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entryThree = new EventTrigger.Entry ();
		entryThree.eventID = EventTriggerType.PointerClick;
		entryThree.callback.AddListener ((data) => {   
			OnPointerClickDelegateChoiceThree ((PointerEventData)data); });
		choiceThreeTrigger.triggers.Add (entryThree);
	}

	public static ModularPanel getInstance(){
		if(!modularPanel){
			modularPanel = FindObjectOfType(typeof (ModularPanel)) as ModularPanel;
			if(!modularPanel)
				Debug.LogError("There needs to be one active ModularPanel script on a Gameobject in your scene.");
		}
		return modularPanel;
	}
		
	public void choice (GameEvent gameEvent){

		if (!gameEvent.getQuestion().Equals ("")) {
			this.question.text = gameEvent.getQuestion();
			this.modularPanelObject.SetActive (true);
		}

		if (gameEvent.getChoiceOneText().Equals("")) {
			this.choiceOne.gameObject.SetActive (false);
			Debug.LogError("At least one option in Modular Panel must be active");
		} else {
			this.choiceOne.gameObject.SetActive (true);
			this.choiceOne.text = gameEvent.getChoiceOneText();
		}
			if (gameEvent.getChoiceTwoText().Equals ("")) {
			this.choiceTwo.gameObject.SetActive (false);
		} else {
			

			this.choiceTwo.gameObject.SetActive (true);
				this.choiceTwo.text = gameEvent.getChoiceTwoText();
		}
		if (gameEvent.getChoiceThreeText().Equals("")) {
			this.choiceThree.gameObject.SetActive (false);
		} else {

			this.choiceThree.gameObject.SetActive (true);
			this.choiceThree.text = gameEvent.getChoiceThreeText();
		}
			
		this.iconImage.gameObject.SetActive (false);
	}

	public void OnPointerClickDelegateChoiceOne(PointerEventData data){
		closePanel ();
		GC.triggerResponse (SelectedChoice.ChoiceOne);
		resetButtonColor ();
	}

	public void OnPointerClickDelegateChoiceTwo(PointerEventData data){
		closePanel ();
		GC.triggerResponse (SelectedChoice.ChoiceTwo);
		resetButtonColor ();
	}

	public void OnPointerClickDelegateChoiceThree(PointerEventData data){
		closePanel ();
		GC.triggerResponse (SelectedChoice.ChoiceThree);
		resetButtonColor ();
	}

	void closePanel(){
		modularPanelObject.SetActive (false);
	}

	void resetButtonColor(){
		choiceOne.color = Color.white;
		choiceTwo.color = Color.white;
		choiceThree.color = Color.white;
	}
}

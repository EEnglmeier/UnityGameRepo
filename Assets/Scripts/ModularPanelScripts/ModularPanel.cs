using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class ModularPanel : MonoBehaviour {
	public Text question;
	public Image iconImage;
	public Text choiceOne;
	public Text choiceTwo;
	public Text choiceThree;
	public GameObject modularPanelObject;

	private static ModularPanel modularPanel;

	public static ModularPanel getInstance(){
		if(!modularPanel){
			modularPanel = FindObjectOfType(typeof (ModularPanel)) as ModularPanel;
			if(!modularPanel)
				Debug.LogError("There needs to be one active ModularPanel script on a Gameobject in your scene.");
		}
		return modularPanel;
	}

	/**
	 * All strings except for question are allowed to be empty.
	 */
	public void choice (string question, string choiceOneString, string choiceTwoString, string choiceThreeString){
		if (!question.Equals ("")) {
			modularPanelObject.SetActive (true);
		}

		if (choiceOneString.Equals ("")) {
			this.choiceOne.gameObject.SetActive (false);
		} else {
			EventTrigger choiceOneTrigger = this.choiceOne.gameObject.GetComponent<EventTrigger> ();
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = EventTriggerType.PointerClick;
			entry.callback.AddListener ((data) => {
				OnPointerClickDelegateChoiceOne ((PointerEventData)data); });
			choiceOneTrigger.triggers.Add (entry);

			addEnterExitTriggers (choiceOneTrigger);

			this.choiceOne.gameObject.SetActive (true);
			this.choiceOne.text = choiceOneString;
		}
		if (choiceTwoString.Equals ("")) {
			this.choiceTwo.gameObject.SetActive (false);
		} else {

			EventTrigger choiceTwoTrigger = this.choiceTwo.gameObject.GetComponent<EventTrigger> ();
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = EventTriggerType.PointerClick;
			entry.callback.AddListener ((data) => {
				OnPointerClickDelegateChoiceTwo ((PointerEventData)data); });
			choiceTwoTrigger.triggers.Add (entry);

			addEnterExitTriggers (choiceTwoTrigger);

			this.choiceTwo.gameObject.SetActive (true);
			this.choiceTwo.text = choiceTwoString;
		}
		if (choiceThreeString.Equals ("")) {
			this.choiceThree.gameObject.SetActive (false);
		} else {

			EventTrigger choiceThreeTrigger = this.choiceThree.gameObject.GetComponent<EventTrigger> ();
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = EventTriggerType.PointerClick;
			entry.callback.AddListener ((data) => {
				OnPointerClickDelegateChoiceThree ((PointerEventData)data); });
			choiceThreeTrigger.triggers.Add (entry);

			addEnterExitTriggers (choiceThreeTrigger);

			this.choiceThree.gameObject.SetActive (true);
			this.choiceThree.text = choiceThreeString;
		}

		this.question.text = question;
		this.iconImage.gameObject.SetActive (false);
	}

	public void OnPointerClickDelegateChoiceOne(PointerEventData data){

		closePanel ();
	}

	public void OnPointerClickDelegateChoiceTwo(PointerEventData data){

		closePanel ();
	}

	public void OnPointerClickDelegateChoiceThree(PointerEventData data){

		closePanel ();
	}
	//TODO this does not really work	
	public void OnPointerEnterDelegate(PointerEventData data,EventTrigger trigger){
		trigger.GetComponent<Text> ().color = Color.gray;
	}
	//TODO this does not really work	
	public void OnPointerExitDelegate(PointerEventData data,EventTrigger trigger){
		trigger.GetComponent<Text> ().color = Color.white;
	}

	private void addEnterExitTriggers(EventTrigger parentTrigger){
		EventTrigger.Entry enterEntry = new EventTrigger.Entry ();
		enterEntry.eventID = EventTriggerType.Move;
		enterEntry.callback.AddListener ((data) => {
			OnPointerEnterDelegate ((PointerEventData)data,parentTrigger); });
		parentTrigger.triggers.Add (enterEntry);

		EventTrigger.Entry exitEntry = new EventTrigger.Entry ();
		enterEntry.eventID = EventTriggerType.PointerExit;
		enterEntry.callback.AddListener ((data) => {
			OnPointerExitDelegate ((PointerEventData)data,parentTrigger); });
		parentTrigger.triggers.Add (exitEntry);
	}
		

	void closePanel(){
		modularPanelObject.SetActive (false);
	}
}

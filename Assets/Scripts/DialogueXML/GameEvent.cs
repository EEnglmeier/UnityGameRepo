using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent{
	private string question = "";
	private string choiceOneText = "";
	private string choiceTwoText = "";
	private string choiceThreeText = "";

	private int responseOneKey = -1;
	private int responseTwoKey = -1;
	private int responseThreeKey = -1;

	public GameEvent(string question, string choiceOneText, string choiceTwoText, string choiceThreeText,int rkOne, int rkTwo, int rkThree){
		this.question = question;
		this.choiceOneText = choiceOneText;
		this.choiceTwoText = choiceTwoText;
		this.choiceThreeText = choiceThreeText;
		this.responseOneKey = rkOne;
		this.responseTwoKey = rkTwo;
		this.responseThreeKey = rkThree;
	}

	public string getQuestion(){
		return question;
	}

	public string getChoiceOneText(){
		return choiceOneText;
	}

	public string getChoiceTwoText(){
		return choiceTwoText;
	}

	public string getChoiceThreeText(){
		return choiceThreeText;
	}

	public int getResponseKeyOne(){
		return responseOneKey;
	}

	public int getResponseKeyTwo(){
		return responseTwoKey;
	}

	public int getResponseKeyThree(){
		return responseThreeKey;
	}
}

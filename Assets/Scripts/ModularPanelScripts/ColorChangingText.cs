using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

/**
 * Changes the color of text on mouse over
 * */
public class ColorChangingText : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

	public void OnPointerExit(PointerEventData eventData){
		gameObject.GetComponent<Text> ().color = Color.white;
	}
	public void OnPointerEnter(PointerEventData eventData){
		gameObject.GetComponent<Text> ().color = Color.gray;
	}
}

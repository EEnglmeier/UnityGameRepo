using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EventProcessor{

	private StartEvent startEvent;
	public GameEvent currentGameEvent;

	public EventProcessor(){
		startEvent = StartEvent.Load(Path.Combine(Application.dataPath, "XMLResources\\StartEvent.xml"));

	}

	public GameEvent getNextEvent(Sector sector, Level level){
		if(sector.Equals(Sector.Start)){
			currentGameEvent = new GameEvent (startEvent.questions [0].text, startEvent.questions [0].responses [0].text,
				startEvent.questions [0].responses [1].text, startEvent.questions [0].responses [2].text,
				startEvent.questions [0].responses [0].nextQuestion,startEvent.questions [0].responses [1].nextQuestion,
				startEvent.questions [0].responses [2].nextQuestion);
		}
		return currentGameEvent;
	}
	//TODO: MERGE WITH GET NEXT EVENT
	public GameEvent getNextDialogueOption(int option){
		currentGameEvent = new GameEvent (startEvent.questions [option].text, startEvent.questions [option].responses [0].text,
			startEvent.questions [option].responses [1].text, startEvent.questions [option].responses [2].text,
			startEvent.questions [option].responses [0].nextQuestion,startEvent.questions [option].responses [1].nextQuestion,
			startEvent.questions [option].responses [2].nextQuestion);
		return currentGameEvent;
	}

}

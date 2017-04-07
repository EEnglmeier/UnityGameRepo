using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO better algorithm for generation positions and position distribution
//Local Map provides a map for the current sub sector
public class LocalMap : IMap {

	private List<ArbitraryMarker> markers;
	//min and max amount of markers to be placed on this map
	private int minAmount, maxAmount;
	//mindist from point to point
	private float minDist,maxDist;

	public LocalMap(List<ArbitraryMarker> markers, int min, int max, float minDist, float maxDist){
		this.minDist = minDist;
		this.maxDist = maxDist;
		this.markers = markers;
		this.minAmount = min;
		this.maxAmount = max;
	}

	//Local maps have a random amount of markers (min, max)
	//LowestX = LeftMost drawable X-Coordinate of the parent map ( 0,0 of a 2d coordsys )
	//HighestY = Hightest drawable Y-Cooridnate of the parent map
	public List<ArbitraryMarker> generateMap (float LowestX,float RightMostX , float HighestY, float LowestY){
		int markerAmount = Random.Range (minAmount, maxAmount);
		Vector2 [] res = generateRandomPositions (this.markers.Capacity,LowestX,RightMostX,HighestY,LowestY);
		if (res.Length != this.markers.Capacity) {
			Debug.LogError ("Unequal length of list and array!!!");
		} else {
			int counter = 0;
			foreach (ArbitraryMarker m in this.markers) {
				m.setPosition (res [counter]);
				counter++;
			}
		}
		return this.markers;
	}

	private Vector2 [] generateRandomPositions(int amount,float leftX,float rightX,float highY,float lowY){
		Vector2 [] resultValues = new Vector2[amount];
		resultValues[0]  = new Vector2 (leftX , 0.0f);
		for(int i=1; i<amount; i++){
			Vector2 p = resultValues [0];
			while(!checkMinMaxDist(p, resultValues)){
				p =  new Vector2(Random.Range(leftX,rightX),Random.Range(lowY,highY));
			}
			resultValues [i] = p;
		}
		return resultValues;
	}

	private bool checkMinMaxDist (Vector2 currentPoint, Vector2 [] toCheck){
		for (int i=0; i<toCheck.Length; i++){
			if (Vector2.Distance (currentPoint, toCheck [i]) < minDist || Vector2.Distance (currentPoint, toCheck [i]) >= maxDist  ) {
				return false;
			}
		}
		return true;
	}

	public IMap getMap(){
		return null;
	}
}

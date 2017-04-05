using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMap {

	List<ArbitraryMarker> generateMap ( float LowestX,float RightMostX, float HighestY, float LowestY);

	IMap getMap();

}

public class ArbitraryMarker{
	private Vector2 position;
	private Sector sector;

	public ArbitraryMarker(float XPosition,float YPosition,Sector sector){
		this.position.x = XPosition;
		this.position.y = YPosition;
		this.sector = sector;
	}

	public void setPosition(Vector2 pos){
		this.position = pos;
	}
	public Vector2 getPosition(){
		return position;
	}
	public Sector getSector(){
		return sector;
	}

	public void setSector(Sector sec){
		this.sector = sec;
	}

	public void setPositonX(float x){
		this.position.x = x;
	}
	public void setPositionY(float y){
		this.position.y = y;
	}
}
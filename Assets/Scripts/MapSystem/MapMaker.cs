using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour {

	public GameObject pirateMarker;
	public GameObject unknownMarker;
	public GameObject shopMarker;
	public GameObject islandMarker;

	public int minAmountOfMarkers;
	public int maxAmountOfMarkers;
	public float minDistBetweenMarkers;
	public float maxDistBetweenMarkers;
	public float xBoarderMargin;
	public float yBoarderMargin;

	private bool generated = false;

	private IMap generatedMap;
	private List<ArbitraryMarker> marker;

	// Use this for initialization
	void Start () {
		if (!generated) {
			marker = generateSectors (minAmountOfMarkers, maxAmountOfMarkers);
			generatedMap = new LocalMap (marker, minAmountOfMarkers, maxAmountOfMarkers, minDistBetweenMarkers, maxDistBetweenMarkers);
			marker = generatedMap.generateMap(-gameObject.GetComponent<Renderer>().bounds.extents.x+xBoarderMargin,
				gameObject.GetComponent<Renderer>().bounds.extents.x-xBoarderMargin,
				gameObject.GetComponent<Renderer>().bounds.extents.y-yBoarderMargin,
				-gameObject.GetComponent<Renderer>().bounds.extents.y+yBoarderMargin);
			foreach (ArbitraryMarker m in marker) {
				switch (m.getSector ()) {
				case Sector.Unknown:
					instantiteSector (unknownMarker,m.getPosition(),Sector.Unknown);
					break;
				case Sector.Start:
					instantiteSector (unknownMarker,m.getPosition(),Sector.Start);
					break;
				case Sector.Final:
					instantiteSector (unknownMarker,m.getPosition(),Sector.Final);
					break;
				case Sector.Pirate:
					instantiteSector (pirateMarker,m.getPosition(),Sector.Pirate);
					break;
				case Sector.Island:
					instantiteSector (islandMarker, m.getPosition (),Sector.Island);
					break;
				case Sector.Shop:
					instantiteSector (shopMarker, m.getPosition (),Sector.Shop);
					break;
				default:
					break;
				}
			}
		}
	}

	private void instantiteSector(GameObject currentMarker,Vector2 pos, Sector sec){
		var inst = Instantiate (currentMarker, new Vector3(pos.x,pos.y,0), transform.rotation);
		inst.transform.parent = this.gameObject.transform;
		inst.GetComponent<Marker> ().setPosition(pos);
		inst.GetComponent<Marker> ().setSector(sec);
	}

	private List<ArbitraryMarker> generateSectors(int min, int max){
		marker = new List<ArbitraryMarker>();
		int amount = Random.Range (min, max);
		for (int i = 0; i < amount; i++) {
			marker.Add (new ArbitraryMarker (0.0f,0.0f,getRandomSector()));
		}
		generated = true;
		marker [0].setSector (Sector.Start);
		marker [maxAmountOfMarkers-1].setSector (Sector.Final);
		return marker;
	}

	private Sector getRandomSector(){
		System.Array ar = System.Enum.GetValues (typeof(Sector));
		Sector sec = Sector.Start;
		while (sec.Equals (Sector.Final) || sec.Equals (Sector.Start)){
			sec = (Sector)ar.GetValue (Random.Range (0, ar.Length));
		}
		return sec;
	}
		
}

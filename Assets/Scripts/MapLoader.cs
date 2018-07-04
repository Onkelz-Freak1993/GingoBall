using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml;



public class MapLoader : MonoBehaviour {
	public TextAsset mapFile;

	public GameObject blueGoal;
	public GameObject redGoal;
	public GameObject yellowGoal;
	public GameObject greenGoal;

	public GameObject whiteBall;
	public GameObject blueBall;
	public GameObject redBall;
	public GameObject yellowBall;
	public GameObject greenBall;


	public GameObject wall;
	public GameObject air;

	public int ballsScored;

	private int ballSpawns = 1;
	private int ballsSpawned = 0;

	private bool blueTarget = false;
	private bool yellowTarget = false;
	private bool redTarget = false;
	private bool greenTarget = false;

	private int sI;
	private GameObject randomObject;
	private bool randSpawn = false;

	private GameObject temp;
	private GameObject[] spawnPoints;

	void Start () {
		string data = mapFile.text;
		parseXmlFile (data);
	}

	public void onScore(){
		Debug.Log ("Scored");
		ballsScored += 1;

		if(ballsScored == ballsSpawned){
			ballsSpawned = 0;
			ballsScored = 0;
			if(ballSpawns <= 20){
				ballSpawns += 1;
			}

			spawnBalls (false);
		}

	}

	void parseXmlFile(string xmlData)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load ( new StringReader(xmlData));

		string xmlPathPattern = "//mapdata/data";
		XmlNodeList myNodeList = xmlDoc.SelectNodes (xmlPathPattern);
		foreach(XmlNode node in myNodeList)
		{
			XmlNode posX = node.FirstChild;
			XmlNode posY = posX.NextSibling;
			XmlNode type = posY.NextSibling;
			createMapTile (int.Parse(posX.InnerXml), int.Parse(posY.InnerXml), int.Parse(type.InnerXml));
		}
		spawnBalls (true);
	}

	public void respawnBall(GameObject ball){
		ball.GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,0);
		sI = Random.Range (0, spawnPoints.Length);
		randomObject = spawnPoints [sI];
		ball.transform.position = randomObject.transform.position+new Vector3(0,0.2f,0);

	}

	void spawnBalls(bool white){
		spawnPoints = GameObject.FindGameObjectsWithTag ("spawnField");
		for(int i=0; ballsSpawned < ballSpawns; i++){
			sI = Random.Range (0, spawnPoints.Length);
			randomObject = spawnPoints [sI];
			randSpawn = false;
			switch (Random.Range (1, 5))
			{
			case 1:
				if(yellowTarget)
					temp = yellowBall;
					ballsSpawned++;
					randSpawn = true;
				break;
			case 2:
				if(blueTarget)
					temp = blueBall;
					ballsSpawned++;
					randSpawn = true;
				break;
			case 3:
				if(redTarget)
					temp = redBall;
					ballsSpawned++;
					randSpawn = true;
				break;
			case 4:
				if(greenTarget)
					temp = greenBall;
					ballsSpawned++;
					randSpawn = true;
				break;
			default:
				break;
			}
			if(randSpawn == true)
				Instantiate (temp, randomObject.transform.position+new Vector3(0,0.2f,0), Quaternion.identity);
		}
		if (white) {
			sI = Random.Range (0, spawnPoints.Length);
			randomObject = spawnPoints [sI];
			Instantiate (whiteBall, randomObject.transform.position, Quaternion.identity);
		}

	}

	void createMapTile(int x, int z , int type){
		// Types: 1 = Yellow Goal, 2 = Blue Goal, 3 = Red Goal, 4 = Green Goal, 5 = ** Goal, 6 = ** Goal, 7 = ** Goal, 8 = ** Goal, 9 = Wall, 10 = Floor
		switch (type)
		{
		case 1:
			Instantiate (yellowGoal, new Vector3 (x, 0, -z), Quaternion.identity);
			yellowTarget = true;
			break;
		case 2:
			Instantiate (blueGoal, new Vector3 (x,0,-z), Quaternion.identity);
			blueTarget = true;
			break;
		case 3:
			Instantiate (redGoal, new Vector3 (x,0,-z), Quaternion.identity);
			redTarget = true;
			break;
		case 4:
			Instantiate (greenGoal, new Vector3 (x,0,-z), Quaternion.identity);
			greenTarget = true;
			break;
		case 5:

			break;
		case 6:

			break;
		case 7:

			break;
		case 8:

			break;
		case 9:
			Instantiate (wall, new Vector3 (x,0,-z), Quaternion.identity);
			break;
		case 10:
			GameObject spawn = Instantiate (air, new Vector3 (x,0,-z), Quaternion.identity);
			spawn.tag = "spawnField";
			break;
		}
	}

}

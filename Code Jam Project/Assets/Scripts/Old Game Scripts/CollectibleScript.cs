using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {

	public static bool redActive = false, blueActive = false, yellowActive = false, greenActive = false, orangeActive = false, magentaActive = false, whiteActive = false;
	public string color;
	public static Vector3 checkpointPosition;
	public int checkpointNumber;
	public int checkpointCount = 0;
	public static bool noCheckpoints;
	public static bool nextLevel = false;

	void Start ()
	{
		if (color == "red" && redActive)
		{
			gameObject.SetActive (false);
		}

		if (color == "blue" && blueActive)
		{
			gameObject.SetActive (false);
		}

		if (color == "yellow" && yellowActive)
		{
			gameObject.SetActive (false);
		}
		if (color == "green" && greenActive)
		{
			gameObject.SetActive (false);
		}
		if (color == "orange" && orangeActive)
		{
			gameObject.SetActive (false);
		}
		if (color == "magenta" && magentaActive)
		{
			gameObject.SetActive (false);
		}

		if (color == "white" && whiteActive && checkpointCount == checkpointNumber)
		{
			gameObject.SetActive (false);
		}
	}

	void Update ()
	{
		if (noCheckpoints)
		{
			checkpointCount = 0;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			switch (color)
			{
			case "red":
				redActive = true;
				gameObject.SetActive (false);
				break;
			
			case "blue":
				blueActive = true;
				gameObject.SetActive (false);
				break;
			
			case "yellow":
				yellowActive = true;
				gameObject.SetActive (false);
				break;
			
			case "green":
				greenActive = true;
				gameObject.SetActive (false);
				break;
			
			case "orange":
				orangeActive = true;
				gameObject.SetActive (false);
				break;
			
			case "magenta":
				magentaActive = true;
				gameObject.SetActive (false);
				break;
			
			case "white":
				checkpointCount++;
				whiteActive = true;
				Respawn.spawnPosition = gameObject.transform.position;
				gameObject.SetActive (false);
				break;
			
			case "black":
				nextLevel = true;
				break;
			
			default:
				break;
			}
		}
	}




}
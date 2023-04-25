using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	public int sceneNumber;
	public Vector3 startPosition;
	public static Vector3 spawnPosition;

	void Start ()
	{
		if (!CollectibleScript.whiteActive)
		{
			spawnPosition = startPosition;
		}

		gameObject.transform.position = spawnPosition;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene (sceneNumber);
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			spawnPosition = startPosition;
			CollectibleScript.redActive = false;
			CollectibleScript.blueActive = false;
			CollectibleScript.yellowActive = false;
			CollectibleScript.greenActive = false;
			CollectibleScript.orangeActive = false;
			CollectibleScript.magentaActive = false;
			CollectibleScript.whiteActive = false;
		}
	}

	public void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Void")
		{
			SceneManager.LoadScene (sceneNumber);
		}
	}


}
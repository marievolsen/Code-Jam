using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

	public GameObject box;

	void Start ()
	{
		box.gameObject.SetActive (false);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (gameObject.tag == "Red")
			{
				if (CollectibleScript.redActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			if (gameObject.tag == "Blue")
			{
				if (CollectibleScript.blueActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			if (gameObject.tag == "Yellow")
			{
				if (CollectibleScript.yellowActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			else if (gameObject.tag == "Green")
			{
				if (CollectibleScript.greenActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			else if (gameObject.tag == "Orange")
			{
				if (CollectibleScript.orangeActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			else if (gameObject.tag == "Magenta")
			{
				if (CollectibleScript.magentaActive)
				{
					box.gameObject.SetActive (true);
				}
			}

			else if (gameObject.tag == "Ground")
			{
				box.gameObject.SetActive (true);
			}

		}
	}

}
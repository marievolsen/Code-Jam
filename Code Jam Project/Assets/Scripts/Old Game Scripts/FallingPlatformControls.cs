using UnityEngine;
using System.Collections;

public class FallingPlatformControls : MonoBehaviour {
	bool isFalling = false;
	float downSpeed = 0.05f;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player")
		{
			isFalling = true;
			Destroy(gameObject, 10);
		}
	}

	void Update()
	{
		if (isFalling)
		{
			downSpeed += Time.deltaTime/20;
			transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
		}
	}
}

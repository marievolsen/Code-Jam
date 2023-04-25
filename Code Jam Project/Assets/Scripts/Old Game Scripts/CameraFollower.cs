using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	
	void Update () {
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform.position);
	}
}

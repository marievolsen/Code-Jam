using UnityEngine;
using System.Collections;

public class JumpPlatform : MonoBehaviour {

	public float jumpForce = 500f;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.attachedRigidbody.AddForce(0f, jumpForce, 0f);
		}
	}
}
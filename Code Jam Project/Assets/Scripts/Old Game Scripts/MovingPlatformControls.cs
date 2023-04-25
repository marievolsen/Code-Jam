using UnityEngine;
using System.Collections;

public class MovingPlatformControls : MonoBehaviour {

	public GameObject startPos;
	public GameObject endPos;
	
	public float speed = 3f;
	
	public bool goForEnd = true;
	
	// Update is called once per frame
	void Update () {
		if (goForEnd) {
			Debug.Log("go for end " + goForEnd);
			transform.Translate ((endPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, endPos.transform.position) <= 1.0f){
				Debug.Log(Vector3.Distance(transform.position, endPos.transform.position) <= 1.0f);
				goForEnd = false;
			}
		}else {
			Debug.Log("go for end " + goForEnd);
			transform.Translate ((startPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, startPos.transform.position) <= 1.0f){
				goForEnd = true;
			}
		}
	}
}
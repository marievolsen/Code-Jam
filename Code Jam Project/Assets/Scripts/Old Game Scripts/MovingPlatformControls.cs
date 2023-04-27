using UnityEngine;
using System.Collections;

public class MovingPlatformControls : MonoBehaviour {

	public GameObject startPos;
	public GameObject endPos;
	public float speed = 3f;
	public bool goForEnd = true;
	
	void Update ()
	{
		if (goForEnd)
		{
			transform.Translate ((endPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, endPos.transform.position) <= 1.0f){
				goForEnd = false;
			}
		}else {
			transform.Translate ((startPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, startPos.transform.position) <= 1.0f){
				goForEnd = true;
			}
		}
	}
}
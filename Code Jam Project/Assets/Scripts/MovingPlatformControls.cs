using UnityEngine;
using System.Collections;

public class MovingPlatformControls : MonoBehaviour {

	public GameObject startPos;
	public GameObject endPos;
	public float speed;
	public bool goForEnd = true;
	[SerializeField] private float proximity;

	void Update ()
	{
		if (goForEnd)
		{
			transform.Translate ((endPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, endPos.transform.position) <= proximity){
				goForEnd = false;
			}
		}else {
			transform.Translate ((startPos.transform.position-transform.position).normalized * speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, startPos.transform.position) <= proximity){
				goForEnd = true;
			}
		}
	}
}
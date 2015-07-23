using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 followPos = new Vector3(target.position.x + 13.5f, transform.position.y, transform.position.z);
		this.transform.position = followPos;
	
	}
}

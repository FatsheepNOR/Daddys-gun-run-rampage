using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	
	public float delay;
	private float currentDelay;

	// Use this for initialization
	void Start () {
		currentDelay = delay;
	}
	
	// Update is called once per frame
	void Update () {
		currentDelay -= 1 * Time.deltaTime;
		if (currentDelay <= 0) {
			Destroy (gameObject);
		}
	}
}

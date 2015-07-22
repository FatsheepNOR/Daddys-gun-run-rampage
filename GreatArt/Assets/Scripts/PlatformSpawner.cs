using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject ground;
	public float delay;

	private float currentDelay;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		currentDelay -= 1 * Time.deltaTime;

		if (currentDelay <= 0 && PlayerMovement.canMove == true) {
			Spawn();
		}
	
	}

	void Spawn () {
		currentDelay = delay;
		Instantiate (ground, transform.position, Quaternion.identity);
	}
}

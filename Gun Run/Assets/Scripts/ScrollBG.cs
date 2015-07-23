using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed;

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.canMove == true) {
			Vector2 offset = new Vector2 (Time.time * speed, 0);
			rend.material.mainTextureOffset = offset;
		}
	}
}

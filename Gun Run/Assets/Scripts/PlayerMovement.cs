using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public static bool canMove;
	public float moveSpeed;
	public float jumpHeight;
	public float jumpDelay;

	private Vector2 moveDir;
	private Vector2 jumpDir;
	private Rigidbody2D R2D;
	private float currentDelay;

	// Use this for initialization
	void Start () {

		R2D = GetComponent<Rigidbody2D> ();
		moveDir = new Vector2 (1, 0);
		jumpDir = new Vector2 (0, 2);
	}
	
	// Update is called once per frame
	void Update () {

		currentDelay -= 1 * Time.deltaTime;
		if (Input.GetButtonDown("Jump") && currentDelay <= 0 && canMove == true) {
			Jump();
		}
			
	}

	void FixedUpdate () {
		if (canMove == true) {
			R2D.transform.Translate (moveDir * moveSpeed);
		}
	}

	public void Jump () {
		if (currentDelay <= 0 && canMove == true) {
			Debug.Log ("JUMP");
			currentDelay = jumpDelay;
			R2D.AddRelativeForce (jumpDir * jumpHeight);
		}
	}

	public void StartMoving () {
		canMove = true;
	}

	public void StopMoving () {
		canMove = false;
	}
}

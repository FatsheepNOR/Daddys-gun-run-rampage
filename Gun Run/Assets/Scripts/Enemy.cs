using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	public float points;
	public int damage;
	public GameObject corpse;
	public GameObject debris;
	public float debrisAmount;
	public float debrisSizeVariation;

	private int currentHealth;
	private float damageDelay;
	private Renderer rend;
	private Color origCol;
	private Quaternion randomRot;

	// Use this for initialization
	void Start () {
		rend = this.gameObject.GetComponent<Renderer> ();
		origCol = rend.material.color;
		currentHealth = health;	
	}
	
	// Update is called once per frame
	void Update () {

		damageDelay -= 1 * Time.deltaTime;

		if (damageDelay <= 0) {
			rend.material.color = origCol;
		}

		if (currentHealth <= 0) {
			Die();
		}
	
	}

	public void TakeDamage (int hp) {

		currentHealth -= hp;
		damageDelay = 0.2f;
		if (rend != null) {
			rend.material.color = new Color (origCol.r + 255, origCol.g, origCol.b, origCol.a);
		}

	}

	void Die () {
		if (corpse != null) {
			Instantiate (corpse, transform.position, transform.rotation);
		}
		if (debris != null) {
			for (var i = 0; i < debrisAmount; i++) {
				randomRot.eulerAngles = new Vector3 (0, 0, Random.Range (1, 360));
				GameObject theDebris = (GameObject) Instantiate(debris, transform.position, randomRot);
				float randomSize = Random.Range(1, 1 + debrisSizeVariation);
				theDebris.transform.localScale = new Vector3(randomSize, randomSize, 1);
				theDebris.GetComponent<Rigidbody2D> ().AddForce (theDebris.transform.right * 10, ForceMode2D.Impulse);

			}
		}
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("TRIGGER");
		if (col.gameObject.name == "Player" && damage != 0) {	
			col.GetComponent<PlayerHealth>().TakeHealth(damage);
		}
	}


}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public static int currentHealth;
	public Image HPBar;

	private Renderer[] rend;
	private Color origCol;
	private float damageDelay;
	private float fillF;
	private float curF;


	// Use this for initialization
	void Start () {

		rend = this.gameObject.GetComponentsInChildren<Renderer> ();
		for (var i = 0; i < rend.Length; i++) {
			origCol = rend[i].material.color;
		}
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
		damageDelay -= 1 * Time.deltaTime;
		curF = currentHealth;
		fillF = curF / 100;
		HPBar.fillAmount = fillF;

		if (damageDelay <= 0) {
			for (var i = 0; i < rend.Length; i++) {
				rend[i].material.color = origCol;
			}
		}
	
	}

	public void TakeHealth (int hp) {
		Debug.Log ("DAMAGE");
		damageDelay = 0.2f;
		currentHealth -= hp;
		Debug.Log ("health is now: " + fillF);
		if (rend != null) {
			for (var i = 0; i < rend.Length; i++) {
				rend[i].material.color = new Color (origCol.r + 255, origCol.g, origCol.b, origCol.a);
			}
		}		
	}	
}

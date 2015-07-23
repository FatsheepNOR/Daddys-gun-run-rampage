using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float minTime;
	public float maxTime;
	public GameObject[] enemies;
	private float time;

	// Use this for initialization
	void Start () {
		time = Random.Range (minTime, maxTime);
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1 * Time.deltaTime;

		if (time <= 0 && PlayerMovement.canMove == true) {
			Spawn();
		}
	
	}

	void Spawn () {
		time = Random.Range (minTime, maxTime);
		Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);

	}
}

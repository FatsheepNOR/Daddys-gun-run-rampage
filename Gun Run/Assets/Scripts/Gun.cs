using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public LayerMask hitAbleLayers;
	public int damage;
	public float delay;
	public float ammo;
	public float ammoConsumption;
	public float reloadTime;
	public float spread;
	public int shots;
	public GameObject trailPrefab;
	public GameObject ejectPrefab;
	public GameObject magPrefab;
	public GameObject flashPrefab;
	public float flashSizeVariation;

	private float currentAmmo;
	private float currentDelay;
	private bool canShoot;
	private bool reloading;
	private Transform ejectT;
	private Transform shotT;
	private Transform magT;
	private Quaternion randomRot;

	// Use this for initialization
	void Start () {
		ejectT = transform.FindChild ("Eject");
		shotT = transform.FindChild ("Shot");
		magT = transform.FindChild ("Mag");
		currentAmmo = ammo;
		currentDelay = 0;
		reloading = false;
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {

		currentDelay -= 1 * Time.deltaTime;

		if (currentAmmo <= 0 || currentDelay > 0 || PlayerMovement.canMove == false) {
			canShoot = false;
		} else if (currentDelay <= 0 && currentAmmo > 0 || PlayerMovement.canMove == true)  {
			canShoot = true;
		}
		
		if (currentAmmo <= 0 && reloading == false && currentDelay <= 0) {
			Reload();
		}
		if (currentDelay <= 0 && reloading == true){
			reloading = false;
			currentAmmo = ammo;
		}

		if (canShoot == true) {
			if (Input.GetButton("Fire1")){
				Shoot();
			}
		}
	
	}

	public void Shoot () {
		if (canShoot == true) {
			currentDelay = delay;
			currentAmmo -= ammoConsumption;

			/*for (var i = 0; i < shots; i++){
			Quaternion spreadRot = new Quaternion (shotT.rotation.x, shotT.rotation.y, shotT.rotation.z + Random.Range(spread * -1, spread), shotT.rotation.w);
			GameObject theBullet = (GameObject) Instantiate (bulletPrefab, shotT.position, spreadRot);
			theBullet.GetComponent<Rigidbody2D>().AddForce(theBullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
		}*/

			for (var i = 0; i < shots; i++) {
				Vector2 shotPoint = new Vector2 (shotT.position.x, shotT.position.y);
				Vector2 shotDir = new Vector2 (shotT.right.x + Random.Range (spread * -1, spread), shotT.right.y + Random.Range (spread * -1, spread));
				RaycastHit2D hit = Physics2D.Raycast (shotPoint, shotDir, 100, hitAbleLayers);
		

				Vector3 lineEnd = Vector3.zero;
				if (hit.collider != null) {
					lineEnd = new Vector3 (hit.point.x, hit.point.y, 0.1f);
				} else {
					lineEnd = new Vector3 (shotDir.x, shotDir.y, 0.1f);
				}

				GameObject theTrail = (GameObject)Instantiate (trailPrefab, shotT.position, Quaternion.identity);
				LineRenderer lr = theTrail.transform.GetComponent<LineRenderer> ();
				lr.SetPosition (0, shotT.position);
				lr.SetPosition (1, lineEnd);

				Enemy health = hit.collider.gameObject.GetComponent<Enemy> ();
				if (health != null) {
					health.TakeDamage (damage);
				}


			}

			if (flashPrefab != null) {
				randomRot.eulerAngles = new Vector3 (0, 0, Random.Range (1, 360));
				GameObject theFlash = (GameObject)Instantiate (flashPrefab, shotT.position, randomRot);
				float randomSize = Random.Range (1, 1 + flashSizeVariation);
				theFlash.transform.localScale = new Vector3 (randomSize, randomSize, 1);
			}
			if (ejectPrefab != null) {
				GameObject theEject = (GameObject)Instantiate (ejectPrefab, ejectT.position, ejectT.rotation);
				theEject.GetComponent<Rigidbody2D> ().AddForce (theEject.transform.up * Random.Range (3.5f, 4.5f), ForceMode2D.Impulse);
			}
		}
	}

	void Reload (){
		currentDelay = reloadTime;
		reloading = true;
		if (magPrefab != null) {
			GameObject theMag = (GameObject)Instantiate (magPrefab, magT.position, magT.rotation);
			theMag.GetComponent<Rigidbody2D> ().AddForce (theMag.transform.up * -4, ForceMode2D.Impulse);
		}
	}
}

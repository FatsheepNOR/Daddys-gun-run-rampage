using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loadout : MonoBehaviour {

	/*public GameObject[] allWeaponsR;
	public GameObject[] allWeaponsL;
	public Transform slotR;
	public Transform slotL;

	private List<int> ownedWeaponIDs = new List<int>();
	private int selectedR;
	private int currentR;
	private int selectedL;
	private int currentL;


	private GameObject gunR;
	private GameObject gunL;





	private bool pistol;
	private bool uzi;

	// Use this for initialization
	void Start () {


		selectedR = PlayerPrefs.GetInt ("currentRWep");
		selectedL = PlayerPrefs.GetInt ("currentLWep");




		pistol = PlayerPrefs.GetInt("pistol",0)>0?true:false;
		uzi = PlayerPrefs.GetInt("uzi",0)>0?true:false;
		UpdateOwned ();
		UpdateWeps ();

		selectedL = 1;
		selectedR = 1;


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateWeps () {


		if (gunR != null) {
			Destroy(gunR);
		}
		if (gunL != null) {
			Destroy(gunL);
		}

		gunR = (GameObject)Instantiate (allWeaponsR[selectedR], slotR.position, slotR.rotation);
		gunR.transform.parent = slotR;
		gunL = (GameObject)Instantiate (allWeaponsL[selectedL], slotL.position, slotL.rotation);
		gunL.transform.parent = slotL;

		SaveWeps ();
	}

	public void UpdateOwned () {
		if (pistol) {
			ownedWeaponIDs.Add(0);
		}
		if (uzi) {
			ownedWeaponIDs.Add(1);
		}
	}

	public void SaveWeps () {
		PlayerPrefs.SetInt ("currentRWep", selectedR);
		PlayerPrefs.SetInt ("currentLWep", selectedL);
		PlayerPrefs.SetInt ("pistol", pistol ? 1 : 0);
		PlayerPrefs.SetInt ("uzi", pistol ? 1 : 0);
	}

	public void NextRight () {
		Debug.Log ("selected: " + currentR);
		currentR +=1;
		if (currentR == ownedWeaponIDs.GetRange) {
			currentR = 0;
		}
		selectedR = ownedWeaponIDs [currentR];

		UpdateWeps ();
	}
	public void PreviousRight () {
		Debug.Log ("selected: " + currentR);
		currentR -= 1;
		if (currentR == -1) {
			currentR = ownedWeaponIDs.Count;
		}
		selectedR = ownedWeaponIDs [currentR];
		UpdateWeps ();
	}*/
}

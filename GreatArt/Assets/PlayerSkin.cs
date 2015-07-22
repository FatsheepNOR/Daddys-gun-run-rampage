using UnityEngine;
using System.Collections;

public class PlayerSkin : MonoBehaviour {

	public Sprite[] heads;
	public Sprite[] bodies;
	public Sprite[] arms;
	public Sprite[] legs;

	private SpriteRenderer head;
	private SpriteRenderer body;
	private SpriteRenderer armR;
	private SpriteRenderer armL;
	private SpriteRenderer legR;
	private SpriteRenderer legL;

	private int currentHead = 0;
	private int currentBody = 0;
	private int currentArms = 0;
	private int currentLegs = 0;


	// Use this for initialization
	void Start () {

		currentHead = PlayerPrefs.GetInt ("currentHead");
		currentBody = PlayerPrefs.GetInt ("currentBody");
		currentArms = PlayerPrefs.GetInt ("currentArms");
		currentLegs = PlayerPrefs.GetInt ("currentLegs");

		head = transform.FindChild ("Head").gameObject.GetComponent<SpriteRenderer> ();
		body = transform.FindChild ("Body").gameObject.GetComponent<SpriteRenderer> ();
		armR = transform.FindChild ("ArmR").gameObject.GetComponent<SpriteRenderer> ();
		armL = transform.FindChild ("ArmL").gameObject.GetComponent<SpriteRenderer> ();
		legR = transform.FindChild ("LegR").gameObject.GetComponent<SpriteRenderer> ();
		legL = transform.FindChild ("LegL").gameObject.GetComponent<SpriteRenderer> ();

		UpdateSkin ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateSkin () {
		head.sprite = heads [currentHead];
		body.sprite = bodies [currentBody];
		armR.sprite = arms [currentArms];
		armL.sprite = arms [currentArms];
		legR.sprite = legs [currentLegs];
		legL.sprite = legs [currentLegs];
	}

	public void NextHead () {
		currentHead += 1;
		if (currentHead == heads.Length) {
			currentHead = 0;
		}
		UpdateSkin ();
	}
	public void PreviousHead () {
		currentHead -= 1;
		if (currentHead == -1) {
			currentHead = heads.Length - 1;
		}
		UpdateSkin ();
	}

	public void NextBody () {
		currentBody += 1;
		if (currentBody == bodies.Length) {
			currentBody = 0;
		}
		UpdateSkin ();
	}
	public void PreviousBody () {
		currentBody -= 1;
		if (currentBody == -1) {
			currentBody = bodies.Length - 1;
		}
		UpdateSkin ();
	}
	public void NextArms () {
		currentArms += 1;
		if (currentArms == arms.Length) {
			currentArms = 0;
		}
		UpdateSkin ();
	}
	public void PreviousArms () {
		currentArms -= 1;
		if (currentArms == -1) {
			currentArms = arms.Length - 1;
		}
		UpdateSkin ();
	}
	public void NextLegs () {
		currentLegs += 1;
		if (currentLegs == legs.Length) {
			currentLegs = 0;
		}
		UpdateSkin ();
	}
	public void PreviousLegs () {
		currentLegs -= 1;
		if (currentLegs == -1) {
			currentLegs = legs.Length - 1;
		}
		UpdateSkin ();
	}
	public void RandomSkin (){
		currentHead = Random.Range (0, heads.Length);
		currentBody = Random.Range (0, bodies.Length);
		currentArms = Random.Range (0, arms.Length);
		currentLegs = Random.Range (0, legs.Length);
		UpdateSkin ();
	}
	public void DefaultSkin (){
		currentHead = 0;
		currentBody = 0;
		currentArms = 0;
		currentLegs = 0;
		UpdateSkin ();
	}

	void OnDestroy () {
		PlayerPrefs.SetInt ("currentHead", currentHead);
		PlayerPrefs.SetInt ("currentBody", currentBody);
		PlayerPrefs.SetInt ("currentArms", currentArms);
		PlayerPrefs.SetInt ("currentLegs", currentLegs);
	}
}

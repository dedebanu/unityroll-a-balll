using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playerControlller : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	public int count;
	public Text countText;
	public Text win;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		countText.text = "Count " + count.ToString ();
		win.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		//speed = 100.0f;
		//Acceleration a;
		float moveHorizontal = Input.GetAxis ("Horizontal")*speed;
		float moveVertical = Input.GetAxis ("Vertical")*speed;
		Vector3 v = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce (v,ForceMode.Acceleration);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count " + count.ToString ();
			if (count == 10) {
				win.text="YouWin!!";
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowCreator : MonoBehaviour {

	public GameObject Enemies;
	public float velX;
	public Vector3 vel;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		vel = new Vector3 (velX, -0.2f, 0f);
		rb = GetComponent<Rigidbody> ();
		rb.velocity = vel;
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.childCount <= 0) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.Equals ("Wall")) {
			velX = -1 * velX;
			vel = new Vector3 (velX, -0.2f, 0f);
			rb.velocity = vel;
		}
	}
}

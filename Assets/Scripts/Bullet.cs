using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float life;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		life = Time.time + (life);
	}
	
	// Update is called once per frame
	void Update () {
		if (life < Time.time) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if (!other.gameObject.tag.Equals ("Row")) {
			Destroy (this.gameObject);
		}
	}
}

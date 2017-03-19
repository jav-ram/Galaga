using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour {

	public Text points;
	public GameObject player;
	public GameObject bullet;
	public GameObject row;
	public int vida;

	private Rigidbody rb;
	private Rigidbody rr;
	private float fireRate;
	private float nextFire;
	private int p = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		points = GameObject.Find ("Points").GetComponent<Text> ();
		fireRate = 1f;
		nextFire = 0f;
		rb = GetComponent<Rigidbody> ();
		row = this.transform.parent.gameObject;
		rr = row.GetComponent<Rigidbody> ();
		rb.velocity = rr.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (onRange() && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bul = Instantiate (bullet, rb.transform.position + new Vector3(0,-1.5f,0), Quaternion.identity);
			bul.transform.parent = GameObject.Find ("Bullets").transform;
			Rigidbody rbb = bul.GetComponent<Rigidbody> ();
			rbb.velocity = new Vector3 (0, -5f, 0);
		}
		rb.velocity = rr.velocity;
	}

	bool onRange(){
		float offset = rb.transform.position.x - player.transform.position.x;
		bool r = (Mathf.Abs (offset) < 2f);
		return r;
	}

	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.name + "," + other.gameObject.tag);
		if (other.gameObject.name == "Bullet(Clone)") {
			Destroy (this.gameObject);
			p = int.Parse(points.text) + 100;
			points.text = ""+p;

		}
	}


}

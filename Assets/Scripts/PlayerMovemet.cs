using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour {

	public Text lives;
	public Text points;
	public GameObject GameOver;
	public GameObject i;
	public float v;
	public float maxV;
	public GameObject bullet;
	public int vida; 

	private float fireRate;
	private float nextFire;
	private Rigidbody rb;
	private float Vx;
	private float Vy;

	// Use this for initialization
	void Start () {
		GameOver.SetActive (false);
		rb = GetComponent<Rigidbody> ();
		Vx=0f;
		Vy=0f;
		fireRate = 0.3f;
		nextFire = 0f;
		vida = 5;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (vida <= 0) {
			GameOver.SetActive (true);
			i.SetActive (true);
			GameOver.GetComponent<Text> ().text = "GameOver " +
				" Points: " + points.text;
			Time.timeScale = 0;
		}

		if (Time.timeScale == 0) {
			if (Input.GetKey (KeyCode.R)) {
				SceneManager.LoadScene ("Start");
				Time.timeScale = 1;
			} else if (Input.GetKey (KeyCode.Space)) {
				SceneManager.LoadScene ("Menu");
				Time.timeScale = 1;
			}
		}
	}

	void Move(){
		Vx = 0f;
		Vy = 0f;
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) && Mathf.Abs(rb.velocity.x) < maxV && Mathf.Abs(rb.velocity.y) < maxV) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				Vx = v;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				Vx = -v;
			}
			rb.AddForce (new Vector3 (Vx, Vy, 0f),ForceMode.Acceleration);
		} 

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bul = Instantiate (bullet, rb.transform.position + new Vector3(0,2f,0), Quaternion.identity);
			bul.transform.parent = GameObject.Find ("Bullets").transform;
			Rigidbody rbb = bul.GetComponent<Rigidbody> ();
			rbb.velocity = new Vector3 (0, 5f, 0);
		} 

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Bullet") {
			vida = vida - 1;
			lives.text = "" + vida;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCreator : MonoBehaviour {

	public GameObject reff;
	public GameObject row1;
	public GameObject row2;
	public float t;

	private GameObject row;
	private int prob;

	// Use this for initialization
	void Start () {
		prob = 90;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > t || this.transform.childCount<=0) {
			prob -= 5;
			t += 10;
				if (Random.Range (0,100) < prob || prob < 0) {
					row = Instantiate (row1, reff.transform.position, Quaternion.identity);
					row.transform.parent = GameObject.Find ("Enemies").transform;
				} else {
					row = Instantiate (row2, reff.transform.position, Quaternion.identity);
					row.transform.parent = GameObject.Find ("Enemies").transform;
				}
		
		}
	}

}

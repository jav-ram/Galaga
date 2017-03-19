using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnStart : MonoBehaviour {
	Button btn;
	// Use this for initialization
	void Start () {
		btn = this.gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		Debug.Log ("click");
		SceneManager.LoadScene ("Start");
	}
}

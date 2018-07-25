using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSpwan : MonoBehaviour {

	private Vector2 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -20)
			ReSpawn ();
	}

	void ReSpawn()
	{
		transform.position = startPosition;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Next")) {
			SceneManager.LoadScene ("NextGame");
		}
	}
}

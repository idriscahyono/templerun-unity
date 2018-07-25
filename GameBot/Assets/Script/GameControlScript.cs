using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {

	public GameObject Image, Image2, Image3, gameOver;
	public static int health;

	// Use this for initialization
	void Start () {
		health = 3;
		Image.gameObject.SetActive (true);
		Image2.gameObject.SetActive (true);
		Image3.gameObject.SetActive (true);
		gameOver.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (health > 3)
			health = 3;

		switch (health) 
		{
		case 3:
			Image.gameObject.SetActive (true);
			Image2.gameObject.SetActive (true);
			Image3.gameObject.SetActive (true);
			break;
		case 2:
			Image.gameObject.SetActive (true);
			Image2.gameObject.SetActive (true);
			Image3.gameObject.SetActive (false);
			break;
		case 1:
			Image.gameObject.SetActive (true);
			Image2.gameObject.SetActive (false);
			Image3.gameObject.SetActive (false);
			break;
		case 0:
			Image.gameObject.SetActive (false);
			Image2.gameObject.SetActive (false);
			Image3.gameObject.SetActive (false);
			gameOver.gameObject.SetActive (true);
			Time.timeScale = 0;
			break;
		}

	}
}

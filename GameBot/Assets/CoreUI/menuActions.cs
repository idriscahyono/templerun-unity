using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuActions : MonoBehaviour {

    public void MENU_ACTION_GotoPAge(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Next")) {
			SceneManager.LoadScene ("NextGame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

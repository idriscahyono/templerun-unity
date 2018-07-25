using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : MonoBehaviour {

    private Animator animatorController;
	// Use this for initialization
	void Start () {
        animatorController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D hit) {
		if(hit.CompareTag("Player"))
        {
            animatorController.SetTrigger("Fall");
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private float xMin, yMin, xMax, yMax;

	private Transform target;
	// Use this for initialization
	void Start () {

		target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbilKunci : MonoBehaviour {

	public Text kunci;
	private bool ambilKunci = false;
	// Use this for initialization
	void Start () {
		UpdateKunci ();
	}

	void OnTriggerenter2D(Collider2D hit)
	{
		if (hit.CompareTag("Kunci")) 
		{
			ambilKunci = true;
			UpdateKunci ();
			Destroy (hit.gameObject);
		}
	}

	private void UpdateKunci()
	{
		string kunciMessage = "Temukan Kunci!!";
		if (ambilKunci) kunciMessage = "Selamat Berhasil Menemukan Kunci";
		kunci.text = kunciMessage;
	}

}

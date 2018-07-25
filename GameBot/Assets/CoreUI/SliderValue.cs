using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

    public Slider sliderUI;
    private Text textSliderValue;
	// Use this for initialization
	void Start () {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
		
	}

    public void ShowSliderValue()
    {
        string sliderMessage = "" +
        sliderUI.value;
        textSliderValue.text = sliderMessage;
    }

    // Update is called once per frame
    void Update () {
		
	}
}

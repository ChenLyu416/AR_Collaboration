using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_text : MonoBehaviour {

    private Slider slider;
    private Text text;


    void Start () {
        
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        text = slider.transform.Find("slider_text").GetComponent<Text>();
        slider.value = 0;
        
        
    }
	
	
	void Update () {
        if (GameObject.Find("Scripts").GetComponent<local_B>().FirstClick)
        {
            text.text = "Please click the button to start the game.";
        }
        else
        {
            text.text = "Cube " + (slider.value).ToString();
        }

    }
}

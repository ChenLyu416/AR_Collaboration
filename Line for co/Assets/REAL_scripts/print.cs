using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class print : MonoBehaviour {

	
	void Start () {
        Text text1 = GameObject.Find("1").GetComponent<Text>();
        text1.text = "Selected?";
        Text text2 = GameObject.Find("2").GetComponent<Text>();
        text2.text = "Selected?";
        Text text3 = GameObject.Find("3").GetComponent<Text>();
        text3.text = "Selected?";
        Text text4 = GameObject.Find("4").GetComponent<Text>();
        text4.text = "Selected?";
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}

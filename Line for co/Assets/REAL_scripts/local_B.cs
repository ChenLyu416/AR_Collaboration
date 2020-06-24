using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class local_B : MonoBehaviour {

    public string ans;
    public bool FirstClick;
    public string name1;

    public void Start()
    {
        name1 = null;
        FirstClick = true;
        


    }

    public void Click()
    {
        print("!!!!!!!!!!!!!!!!!!clicked!!!!!!!!!!!!!!!!!!!!!");

        if (FirstClick)
        {
            name1 = randomCube();
           
            GameObject.Find("theLine").GetComponent<color_changer>().photonView.RPC
                           ("changeColor", PhotonTargets.Others, name1);
           
            
            GameObject.Find("Scripts").GetComponent<local_control>().ResetTime();
             FirstClick = false;
        }
        else
        {
            float index_name = GameObject.Find("Slider").GetComponent<Slider>().value;
            ans = "Cube (" + index_name + ")";

            GameObject.Find("Scripts").GetComponent<local_control>().ResetTime();
            GameObject.Find("Scripts").GetComponent<local_control>().RecordB();
            GameObject.Find("Scripts").GetComponent<local_control>().RecordAns(ans);

            GameObject.Find("Scripts").GetComponent<local_control>().RecordTask(name1);

            GameObject.Find("theLine").GetComponent<color_changer>().photonView.RPC
                         ("changeBack", PhotonTargets.All, name1);
            name1 = randomCube();
            GameObject.Find("theLine").GetComponent<color_changer>().photonView.RPC
                         ("changeColor", PhotonTargets.All, name1);

            GameObject.Find("Scripts").GetComponent<local_control>().Next();

        }
        
    }

    public string randomCube()
    {
        int theIndex = Random.Range(1, 16);


        string indexname = theIndex.ToString();
        string name_ = "Cube (" + indexname + ")";
        return name_;
    }



}

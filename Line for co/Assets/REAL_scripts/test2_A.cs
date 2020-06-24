using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test2_A : MonoBehaviour
{

    public string name1;
    public bool FirstClick;


    public void Start()
    {
        name1 = "Cube (1)";
        if (PhotonNetwork.isMasterClient)
        {
            Text text = GameObject.Find("select_text").GetComponent<Text>();
            text.text = "Please click the button to start the game.";
            FirstClick = true;
        
            for (int i = 1; i <= 10; i++)
            {
                Text text_ = GameObject.Find(i.ToString()).GetComponent<Text>();
                text_.text = "";
            }
            GameObject.Find("MetaCanvasB").SetActive(false);
        }
        else
        {
            GameObject.Find("MetaCanvasA").SetActive(false);
        }

    }

 
    public void Click()
    {
        if (PhotonNetwork.isMasterClient)
        {
            print("!!!!!!!!!!!!!!!!!!clicked!!!!!!!!!!!!!!!!!!!!!");


            if (FirstClick)
            {
                Text text = GameObject.Find("select_text").GetComponent<Text>();
                text.text = "Selected?";
                name1 = randomCube();
                changeColor(name1);
                GameObject.Find("Scripts").GetComponent<local_control>().ResetTime();
                FirstClick = false;
            }

            else
            {

                GameObject.Find("Scripts").GetComponent<local_control>().ResetTime();
                GameObject.Find("Scripts").GetComponent<local_control>().RecordTask(name1);

                changeBack(name1);
                name1 = randomCube();



            }
        }

    }


    public string randomCube()
    {
        if (PhotonNetwork.isMasterClient)
        {
            int theIndex = Random.Range(1, 16);


            string indexname = theIndex.ToString();
            string name_ = "Cube (" + indexname + ")";
            return name_;
        }
        else
        {
            return "";
        }

    }


    public void changeColor(string obj)
    {
        if (PhotonNetwork.isMasterClient)
        {
            Material _renderMaterial;
            GameObject target = GameObject.Find(obj);
            Renderer renderer = target.GetComponent<Renderer>();
            _renderMaterial = renderer.material;
            _renderMaterial.color = Color.blue;
        }
    }


    public void changeBack(string obj)
    {
        if (PhotonNetwork.isMasterClient)
        {
            Material _renderMaterial;
            GameObject target = GameObject.Find(obj);
            Renderer renderer = target.GetComponent<Renderer>();
            _renderMaterial = renderer.material;
            _renderMaterial.color = Color.white;
        }
    }


}

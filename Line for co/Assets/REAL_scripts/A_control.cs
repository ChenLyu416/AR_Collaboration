using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class A_control : Photon.PunBehaviour
{
    public string name1;
    
    public void Start()
    {

        name1 = randomCube();

        showTask(name1);

        if (PhotonNetwork.connected)
        {
            GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                ("ResetTime", PhotonTargets.All);
        }
    }


    public void Click()
    {
        print("!!!!!!!!!!!!!!!!!!clicked!!!!!!!!!!!!!!!!!!!!!");

        GameObject.Find("Scripts").GetComponent<Control>().
            photonView.RPC("ResetTime", PhotonTargets.All);
        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                                ("RecordA", PhotonTargets.All);
        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                                ("RecordTask", PhotonTargets.All, name1);



        changeBack(name1);
        name1 = randomCube();
        showTask(name1);



        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                               ("ConvertPri", PhotonTargets.All);

    }


    public string randomCube()
    {
        int theIndex = Random.Range(1, 16);
        string indexname = theIndex.ToString();
        string name_ = "Cube (" + indexname + ")";
        return name_;
    }


    public void showTask(string obj)
    {
        Text text = GameObject.FindGameObjectWithTag("task").GetComponent<Text>();
        text.text = "Please choose "+obj;

    }


    public void changeBack(string obj)
    {
        Material _renderMaterial;
        GameObject target = GameObject.Find(obj);
        Renderer renderer = target.GetComponent<Renderer>();
        _renderMaterial = renderer.material;
        _renderMaterial.color = Color.white;
    }

    

}

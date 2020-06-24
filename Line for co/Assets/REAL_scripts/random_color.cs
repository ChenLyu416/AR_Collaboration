using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class random_color : Photon.PunBehaviour
{
    public string name1;

    static public Control Ctr;

    public void Start()
    {
        
        name1 = randomCube();

        changeColor(name1);

        if (PhotonNetwork.connected)
        {
            Ctr = GameObject.Find("Scripts").GetComponent<Control>();
            Ctr.photonView.RPC("ResetTime", PhotonTargets.All);
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
                                                ("RecordTask", PhotonTargets.All,name1);
        


        changeBack(name1);
        name1 = randomCube();
        changeColor(name1);

        

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


    public void changeColor(string obj)
    {
        Material _renderMaterial;
        GameObject target = GameObject.Find(obj);
        Renderer renderer = target.GetComponent<Renderer>();
        _renderMaterial = renderer.material;
        _renderMaterial.color = Color.blue;
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



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class color_changer : Photon.PunBehaviour
{
    public int index;

    public void Start()
    {
        index = 0;
    }

    public void Update()
    {
        if (PhotonNetwork.isMasterClient)
        { if (index >= 11)
        {
            SceneManager.LoadScene(11);
        }
        }
        

    }


    [PunRPC]
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
        index++;
    }

    [PunRPC]
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

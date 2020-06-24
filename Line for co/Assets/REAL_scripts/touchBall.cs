using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchBall : MonoBehaviour {

    Material _renderMaterial;
    public bool wsl;

    public void Start()
    {
        wsl = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (wsl)
        { 
           GameObject.Find("Scripts").GetComponent<local_B>().Click();
           wsl = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        Material _renderMaterial = renderer.material;
        _renderMaterial.color = Color.green;

    }

    void OnTriggerExit(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        Material _renderMaterial = renderer.material;
        _renderMaterial.color = Color.white;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_touch : MonoBehaviour {
    
    
    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("ball").GetComponent<touchBall>().wsl = true;
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

using ExitGames.UtilityScripts;
using Meta;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestureC_share : Photon.PunBehaviour
{
    public LineRenderer rayLine;

    public Vector3 centerPosition = new Vector3(0, 0, 0);
    public Vector3 dire = new Vector3(0, 0, 100);


    public void Start()
    {
        rayLine = GetComponent<LineRenderer>() as LineRenderer;
        rayLine.SetPosition(0, centerPosition);
        rayLine.SetPosition(1, dire);
    }

    
    [PunRPC]
    public void resetPosition(Vector3 center, Vector3 top)
    {
        rayLine.SetPosition(0, center);
        rayLine.SetPosition(1, 100 * top - 99 * center);
    }


    [PunRPC]
    public void changeColor1(string name)
    {
        Material _renderMaterial;
        GameObject Change = GameObject.Find(name);
        Renderer renderer = Change.GetComponent<Renderer>();
        _renderMaterial = renderer.material;
        _renderMaterial.color = Color.yellow;
    }

    [PunRPC]
    public void changeColorback(string name)
    {
        Material _renderMaterial;
        GameObject Change = GameObject.Find(name);
        Renderer renderer = Change.GetComponent<Renderer>();
        _renderMaterial = renderer.material;
        _renderMaterial.color = Color.white;
    }

}
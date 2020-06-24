using Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class gesture_share : Photon.PunBehaviour
{

    public LineRenderer rayLine;

    public Vector3 centerPosition;
    public Vector3 dire;
    

    void Start ()
    {
        centerPosition = new Vector3(0, 0, 0);
        dire = new Vector3(0, 0, 100);

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
}

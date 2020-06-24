using Meta;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaze_control : Photon.PunBehaviour
{

    public Vector3 Dire;
    public Vector3 Posit;


    void Start()
    {
        Dire = new Vector3(0, 0, 0);
        Posit = new Vector3(0, 0, 0);
    }

    public void Update()
    {
            Dire = GameObject.FindGameObjectWithTag("ad").transform.position;
            Posit = GameObject.FindGameObjectWithTag("camera").GetComponent<EventCamera>().Position;

            if (PhotonNetwork.connected)
            {
                GameObject.Find("theLine").GetComponent<gaze_share>().photonView.RPC
                           ("resetPosition", PhotonTargets.All,Posit, Dire);
            }
        

    }

   
}


using Meta;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazeC_control : Photon.PunBehaviour
{
    public Ray castRay;

    public Vector3 Dire;
    public Vector3 Posit;
    public Vector3 bais;
    public Vector3 down;
    
    public bool isCollided = false;

    string objName = null;

    void Start()
    {
        bais = new Vector3(0, 0, 0.1f);
        down = new Vector3(0, -0.04f, 0);
    }

    public void Update()
    {
        
            Posit= GameObject.FindGameObjectWithTag("ad").transform.position;
            Dire = GameObject.FindGameObjectWithTag("camera").GetComponent<EventCamera>().Position;
            castRay = new Ray(Posit + bais+ down, 100 * Dire - 99 * Posit+50*down);


            objName = collide();

            if (PhotonNetwork.connected)
            {
                GameObject.Find("theLine").GetComponent<gazeC_share>().photonView.RPC
                           ("resetPosition", PhotonTargets.All, Dire, Posit);
                GameObject.Find("theLine").GetComponent<gazeC_share>().photonView.RPC
                ("changeColor1", PhotonTargets.All, objName, isCollided);
            }
        
        isCollided = false;
    }

    public string collide()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(castRay, out hitInfo))
        {
            isCollided = true;
            GameObject colliObj = hitInfo.collider.gameObject;
            Debug.Log("click object name is " + colliObj.name);
            objName = colliObj.name;
        }
        return objName;
    }


}


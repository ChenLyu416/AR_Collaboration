using ExitGames.UtilityScripts;
using Meta;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestureC_control : MonoBehaviour
{
    public Ray castRay;

    public Vector3 centerPosition;
    public Vector3 dire;
    public Vector3 bais;

    public GameObject hand;

    public bool isCollided = false;

    string objName = null;

    string theName = null;


    void Start ()
    {
        centerPosition = new Vector3(0, 0, 0);
        dire = new Vector3(0, 0, 0);
        bais = new Vector3(0.1f, 0.1f, 0.1f);
     }
	
	void Update ()
    {
        setHand();


        if (PhotonNetwork.connected)
        {
            GameObject.Find("theLine").GetComponent<gestureC_share>().photonView.RPC
                ("resetPosition", PhotonTargets.All, centerPosition, dire);
        }

         objName = collide();

       

        if (PhotonNetwork.connected)
        {
            if ((objName == theName) && (!isCollided))
            {
                GameObject.Find("theLine").GetComponent<gestureC_share>().photonView.RPC
                    ("changeColorback", PhotonTargets.All, objName);
            }
            else
            {
                GameObject.Find("theLine").GetComponent<gestureC_share>().photonView.RPC
                    ("changeColor1", PhotonTargets.All, objName);
            }
        }

        isCollided = false;

    }

    public void setHand()
    {
        if (GameObject.Find("MetaHands").GetComponent<HandsProvider>().ActiveHands.Count != 0)
        {
            hand = GameObject.FindGameObjectWithTag("leftP");
            if (hand != null)
            {
                centerPosition = hand.GetComponent<Meta.HandInput.CenterHandFeature>().Position;
                dire = GameObject.FindGameObjectWithTag("leftT").GetComponent<Meta.HandInput.TopHandFeature>().Position;
            }
        }

        castRay = new Ray(dire + bais, 100 * dire - 99 * centerPosition);

    }


    public string collide()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(castRay, out hitInfo))
        {
            isCollided = true;
            GameObject colliObj = hitInfo.collider.gameObject;
            Debug.Log("click object name is " + colliObj.name);
            theName = colliObj.name;
            if(objName != theName)
            {
                GameObject.Find("theLine").GetComponent<gestureC_share>().photonView.RPC
                ("changeColorback", PhotonTargets.All, objName);
            }
        }
        return theName;
    }




}

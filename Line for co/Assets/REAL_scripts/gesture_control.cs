using Meta;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class gesture_control : MonoBehaviour
{
    public GameObject hand;

    public Vector3 centerPosition;
    public Vector3 dire;

    void Start ()
    {
        hand = null;
        
    }
	

	void Update ()
    {
		 setHand();

        if (PhotonNetwork.connected)
        {
            GameObject.Find("theLine").GetComponent<gesture_share>().photonView.RPC
                ("resetPosition", PhotonTargets.All, centerPosition, dire);
        }

	}


    public void setHand()
    {
        if (GameObject.Find("MetaHands").GetComponent<HandsProvider>().ActiveHands.Count != 0)
        {
            hand = GameObject.FindGameObjectWithTag("P");
            if (hand != null)
            {
                centerPosition = hand.GetComponent<Meta.HandInput.CenterHandFeature>().Position;
                dire = GameObject.FindGameObjectWithTag("T").GetComponent<Meta.HandInput.TopHandFeature>().Position;
            }
        }
    }

}

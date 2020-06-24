using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Answer : Photon.PunBehaviour
{

    public string ans;

    public void Click()
    {
        float index_name = GameObject.Find("Slider").GetComponent<Slider>().value;
        ans = "Cube (" + index_name + ")";

        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                                ("ResetTime", PhotonTargets.All);
        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                                ("RecordB", PhotonTargets.All);

        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                               ("RecordAns", PhotonTargets.All, ans);

        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                               ("Next", PhotonTargets.All);

        GameObject.Find("Scripts").GetComponent<Control>().photonView.RPC
                                              ("ConvertPri", PhotonTargets.All);

        
    }

}

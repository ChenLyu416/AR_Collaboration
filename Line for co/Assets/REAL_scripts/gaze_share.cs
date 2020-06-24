using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaze_share : Photon.PunBehaviour
{
    public LineRenderer rayLine;

    public Vector3 Init;

    public Vector3 Dire;

    public Vector3 Down;
    

    void Start () {
        Init = new Vector3(0, 0, 0);
        Dire = new Vector3(0, 0, 0);
        Down = new Vector3(0, -0.04f, 0);

        rayLine = GetComponent<LineRenderer>() as LineRenderer;
        rayLine.SetPosition(0, Init);
        rayLine.SetPosition(1, Dire);
    }
	
	
	void Update () {
		
	}


    [PunRPC]
    public void resetPosition(Vector3 position,Vector3 now)
    {
        rayLine.SetPosition(0, position+ Down);
        rayLine.SetPosition(1, 100 * position - 99* now+50*Down);
    }

   

}

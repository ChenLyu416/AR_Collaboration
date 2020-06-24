using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazeC_share : Photon.PunBehaviour
{
    

    public LineRenderer rayLine;

    public Vector3 Init;
    public Vector3 bais;
    public Vector3 down;

    void Start()
    {
        Init = new Vector3(0, 0, 0);

        rayLine = GetComponent<LineRenderer>() as LineRenderer;
        rayLine.SetPosition(0, Init);

        bais = new Vector3(0, 0, 0.08f);
        down = new Vector3(0, -0.04f, 0);
    }
    


    [PunRPC]
    public void resetPosition(Vector3 position, Vector3 now)
    {
        rayLine.SetPosition(0, position+bais+down);
        rayLine.SetPosition(1, 100 * position - 99 * now +50*down);
    }

    [PunRPC]
    public void changeColor1(string name, bool isCollided)
    {
        Material _renderMaterial;
        GameObject Change = GameObject.Find(name);
        Renderer renderer = Change.GetComponent<Renderer>();
        _renderMaterial = renderer.material;

        if (isCollided)
        {
            _renderMaterial.color = Color.yellow;
        }
        else
        {
            _renderMaterial.color = Color.white;
        }

    }

}

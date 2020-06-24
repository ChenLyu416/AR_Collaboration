using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : Photon.PunBehaviour
{

    public float[] timeA;
    public float[] timeB;

    public string[] tasks;
    public string[] answers;

    public int index;

    public float beginTime;
    public float endTime;
    public float period;

    public int privilege;

    void Start ()
    {
        timeA = new float[10];
        timeB = new float[10];

        tasks = new string[10];
        answers = new string[10];

        index = 0;

        beginTime = 0;
        endTime = 0;
        period = 0;

        privilege = 0;
    }
	
	
	void Update ()
    {
        
        if (index >= 10)
        {
            End();
        }


        if (privilege == 0)
        {
            Text text = GameObject.FindGameObjectWithTag("hint").GetComponent<Text>();
            text.text = "A choose";
        }
        else
        {
            Text text = GameObject.FindGameObjectWithTag("hint").GetComponent<Text>();
            text.text = "B choose";
        }

    }


    [PunRPC]
    public void ResetTime()
    {
        endTime = Time.time;
       
        period = endTime - beginTime;
        beginTime = endTime;
    }

    [PunRPC]
    public void RecordA()
    {
        timeA[index] = period;
    }

    [PunRPC]
    public void RecordB()
    {
        timeB[index] = period;
    }

    [PunRPC]
    public void RecordTask(string task)
    {
        tasks[index] = task;
    }

    [PunRPC]
    public void RecordAns(string ans)
    {
        answers[index] = ans;
    }

    [PunRPC]
    public void ConvertPri()
    {
        if (privilege == 0)
        {
            privilege = 1;
        }
        else
        {
            privilege = 0;
        }
    }

    [PunRPC]
    public void Next()
    {
        index++;
    }

   
    public void End()
    {
        SceneManager.LoadScene(11);
        print(timeA);
        print(timeB);
        print(tasks);
        print(answers);
        
    }

    void OnPhotonSerializeView()
    { }

}

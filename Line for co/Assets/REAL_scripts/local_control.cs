using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable]
public class local_control : MonoBehaviour
{
    
    public float[] timeB;

    public string[] tasks;
    public string[] answers;

    public int index;

    public float beginTime;
    public float endTime;
    public float period;
    

    

    void Start()
    {
        
        timeB = new float[10];

        tasks = new string[10];
        answers = new string[10];

        index = 0;

        beginTime = 0;
        endTime = 0;
        period = 0;


    }


    void Update()
    {

        if (index >= 10)
        {
            
            End();
            SceneManager.LoadScene(11);
        }

        

    }
    
    public void ResetTime()
    {
        endTime = Time.time;

        period = endTime - beginTime;
        beginTime = endTime;
    }

   


    public void RecordB()
    {
        timeB[index] = period;
    }


    public void RecordTask(string task)
    {
        tasks[index] = task;
    }

 
    public void RecordAns(string ans)
    {
        answers[index] = ans;
    }
    
   
    public void Next()
    {
        index++;
    }


    public void End()
    {
        writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result", "time: ");
        for (int i = 0;i<=9;i++)
        {
            writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result",
                timeB[i].ToString()+", ");
        }

        writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result", "task: ");
        for (int i = 0; i <= 9; i++)
        {
            writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result",
                tasks[i].ToString() + ", ");
        }

        writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result", "answer: ");
        for (int i = 0; i <= 9; i++)
        {
            writeTXT("C:\\Users\\CSSE VRLab Dell #2\\Desktop\\results", "result",
                answers[i].ToString() + ", ");
        }

    }




    public void writeTXT(string file_path, string file_name, string str_info)

    {

        StreamWriter sw;
        if (!File.Exists(file_path + "//" + file_name))
        {
            sw = File.CreateText(file_path + "//" + file_name);
            Debug.Log("文件创建成功！");

        }

        else

        {

            sw = File.AppendText(file_path + "//" + file_name);
        }

        sw.WriteLine(str_info);

        sw.Close();

        sw.Dispose();

    }



}

 


    



    

   



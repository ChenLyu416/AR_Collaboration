using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class begin_scence : MonoBehaviour {

    
    Dropdown dropdownUser;
    Dropdown dropdownTask;

    int user;
    int task;



    public void Start()
    {
        
        dropdownUser = GameObject.Find("User").GetComponent<Dropdown>();
        dropdownTask = GameObject.Find("Task").GetComponent<Dropdown>();

       
        dropdownUser.onValueChanged.AddListener(changeUser);
        dropdownTask.onValueChanged.AddListener(changeTask);

    }


    


    public void changeUser(int index)
    {
        user = index;
        
       
    }


    public void changeTask(int index)
    {
        task = index;
    }


    public void Click()
    {
        if (user == 0)
        {
            switch(task)
            {
                case 1: 
                    SceneManager.LoadScene(1);
                    break;
                case 2:
                    SceneManager.LoadScene(2);
                    break;
                case 3:
                    SceneManager.LoadScene(4);
                    break;
                case 4:
                    SceneManager.LoadScene(3);
                    break;
                case 5:
                    SceneManager.LoadScene(5);
                    break;
            }
        }
        else
        {
            switch (task)
            {
                case 1:
                    SceneManager.LoadScene(6);
                    break;
                case 2:
                    SceneManager.LoadScene(7);
                    break;
                case 3:
                    SceneManager.LoadScene(9);
                    break;
                case 4:
                    SceneManager.LoadScene(8);
                    break;
                case 5:
                    SceneManager.LoadScene(10);
                    break;
            }
        }
    }


    
}

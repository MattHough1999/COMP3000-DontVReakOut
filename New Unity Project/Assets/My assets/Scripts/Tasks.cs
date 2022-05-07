using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Tasks : MonoBehaviour
{
    [SerializeField] GameObject phone, COD, fireAlarm, kettle;
    [SerializeField] TextMeshPro win, loss, taskText,timeText;
    float timer = 1000;
    int completedTasks = 0, failedTasks = 0, task = 10;
    bool taskInProgress = false;
    
    // Start is called before the first frame update
    void Start()
    {
        taskInProgress = false;
        newTask();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0) 
        {
            PlayerPrefs.SetInt("completedTasks",completedTasks);
            PlayerPrefs.SetInt("failedTasks", failedTasks);
            SceneManager.LoadScene("End");
        }
        timer = timer - Time.deltaTime;
        timeText.text = "Time Remaining: " + timer.ToString();
    }

    public void newTask() 
    {
        
        if(taskInProgress == true) 
        {
            switch (task) 
            {
                case 0:
                    phone.GetComponent<Phone>().failedTask();
                    break;
                case 1:
                    COD.GetComponent<ChestOfDrawers>().failedTask();
                    break;
                case 2:
                    fireAlarm.GetComponent<FireAlarm>().failedTask();
                    break;
                case 3:
                    kettle.GetComponent<Kettle>().failedTask();
                    break;
            }
            Debug.Log("Failed Task: " + task);
            // MAKE SURE subPoint(); IS IN ALL FAILED TASK METHODS
        }
        task = Random.Range(0, 4);
        
        switch (task)
        {
            case 0:
                int code = Random.Range(1000, 10000);
                phone.GetComponent<Phone>().setCorrCode(code.ToString());
                taskText.text = "Enter: " + code + " on the phone!";
                taskInProgress = true;
                break;
            case 1:
                int drawer = Random.Range(0, 12);
                COD.GetComponent<ChestOfDrawers>().newTask(drawer.ToString());
                taskText.text = "Place a cup in Drawer: " + drawer + "!";
                taskInProgress = true;
                break;
            case 2:
                fireAlarm.GetComponent<FireAlarm>().goingOff();
                taskText.text = "Punch the fireAlarm!";
                taskInProgress = true;
                break;
            case 3:
                kettle.GetComponent<Kettle>().newTask();
                taskText.text = "Put the kettle on!";
                taskInProgress = true;
                break;

        }
        Debug.Log("Made Task: " + task);
    }
    public void addPoint() 
    {
        taskInProgress = false;
        completedTasks++;
        win.text = "Successful Tasks: " + completedTasks;
        PlayerPrefs.SetInt("completedTasks", PlayerPrefs.GetInt("completedTasks") + 1);
        newTask();
    }
    public void subPoint()
    {

        taskInProgress = false;
        failedTasks++;
        loss.text = "Failed Tasks: " + failedTasks;
        PlayerPrefs.SetInt("failedTasks", PlayerPrefs.GetInt("failedTasks") + 1);
        newTask();
    }
}

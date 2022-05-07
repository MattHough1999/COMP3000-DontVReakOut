using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarm : MonoBehaviour
{
    [SerializeField] GameObject tasks;
    [SerializeField] Transform startPos;

    public bool pulled = false;
    bool isGoingOff = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pulled == true && isGoingOff == true) 
        {
            tasks.GetComponent<Tasks>().addPoint();
            pulled = false;
            isGoingOff = false;
        }
    }
    public void goingOff() 
    {
        isGoingOff = true;
    }
    public void failedTask() 
    {
         tasks.GetComponent<Tasks>().subPoint();
    }
    public void fireAlarmPulled() 
    {
        pulled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOfDrawers : MonoBehaviour
{
    [SerializeField] GameObject tasks;
    string targetDrawer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newTask(string drawer) 
    {
        targetDrawer = drawer;
    }
    public void drawerTriggered(string drawer)
    {
        if (drawer != targetDrawer)
        {
            failedTask();
        }
        else tasks.GetComponent<Tasks>().addPoint();
    }
    public void failedTask() 
    {
        tasks.GetComponent<Tasks>().subPoint();
    }
}

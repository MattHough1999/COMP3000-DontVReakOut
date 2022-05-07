using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kettle : MonoBehaviour
{
    [SerializeField] GameObject tasks;
    [SerializeField] SnapToReset reset;
    //[SerializeField] Collider collider;
    float boilTimer = 5;
    public bool onBoil = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onBoil == true) 
        {
            boilTimer = boilTimer - Time.deltaTime;
            
        }
        if(onBoil == false && boilTimer <= 5.00f) 
        {
            boilTimer = boilTimer + (Time.deltaTime / 2);
        }
        if(boilTimer <= 0) 
        {
            boilTimer = 5;
            taskComplete();
        }
        
    }
    
    public void newTask() 
    {
        reset.resetFromOutZone();
        boilTimer = 1;
        onBoil = false;
    }
    public void taskComplete() 
    {
        reset.resetFromOutZone();
        tasks.GetComponent<Tasks>().addPoint();    
    }
    public void failedTask() 
    {
        reset.resetFromOutZone();
        tasks.GetComponent<Tasks>().subPoint();
    }
}

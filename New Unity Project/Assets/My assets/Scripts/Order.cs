using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
struct order
{
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    public bool Complete;
    public string Name;
    public GameObject[] components;

    //Constructor (not necessary, but helpful)
    public order(bool complete, string name, GameObject[] comp)
    {
        this.Complete = complete;
        this.Name = name;
        this.components = comp;
    }
}

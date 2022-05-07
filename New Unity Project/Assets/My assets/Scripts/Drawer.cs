using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    [SerializeField] ChestOfDrawers cod;
    int drawerID;
    // Start is called before the first frame update
    void Start()
    {
        //drawerID = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + other.gameObject.tag + other.transform.tag);
        if(other.tag == "Cup" || other.gameObject.tag == "Cup" || other.transform.tag == "Cup") 
        {
            cod.drawerTriggered(gameObject.name);
            Destroy(other.gameObject);
        }
        
        
    }
    
}

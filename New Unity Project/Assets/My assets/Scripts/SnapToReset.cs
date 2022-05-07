using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToReset : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Reset;

    Rigidbody rb;
    bool inZone = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == Reset.gameObject.name)
        {
            inZone = true;
            Debug.Log("InZone");
        }
    }

    /*

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == Reset.gameObject.name)
        {
            inZone = true;
            Debug.Log("InZone");
        }
    }

    */

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == Reset.gameObject.name)
        {
            inZone = false;
            Debug.Log("OutZone");
        }
    }
    public void ResetPos() 
    {
        if(inZone == true) 
        {
            gameObject.transform.position = Reset.transform.position;
            gameObject.transform.rotation = Reset.transform.rotation;
            rb.velocity = Vector3.zero;
        }
    }
    public void resetFromOutZone() 
    {
        gameObject.transform.position = Reset.transform.position;
        gameObject.transform.rotation = Reset.transform.rotation;
        rb.velocity = Vector3.zero;
    }
}

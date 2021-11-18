using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lol : MonoBehaviour
{
    Rigidbody rb;
    Collider col;
    public bool connected = true;
    public bool smashed = false;
    public float vel = 0.1f;
    float comVel = 0.0f;
    Vector3 RelVel = Vector3.zero;
    List<GameObject> gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            connected = false; 
        }
        if (connected == false && smashed != true)
        {
            smashed = true;
            rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rb.constraints = RigidbodyConstraints.None;
            Instantiate(gameObject, transform.position, transform.rotation); 
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            RelVel = other.gameObject.GetComponent<Rigidbody>().velocity - gameObject.GetComponentInParent<Rigidbody>().velocity;
            comVel = RelVel.x + RelVel.y + RelVel.z;
            if (gameObject.tag != other.gameObject.tag && connected != false)
            {
                connected = false;
            }
        }
    }
}
    

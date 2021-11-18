using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public float resetTime = 100005.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       //photocopier that overheats if on too long
        
       // gameObject.transform.position = gameObject.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(-1.5f, 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if(resetTime <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
        resetTime = resetTime - Time.deltaTime;
    }
}

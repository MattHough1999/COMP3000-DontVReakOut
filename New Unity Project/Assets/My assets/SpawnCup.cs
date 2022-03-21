using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCup : MonoBehaviour
{
    [SerializeField] GameObject Cup;
    [SerializeField] GameObject CupSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCup() 
    {
        Instantiate(Cup,CupSpawn.transform);
    }
}

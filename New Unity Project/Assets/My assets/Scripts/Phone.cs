using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    // Start is called before the first frame update
    bool Correct = false;
    string Code, CorrCode;
    int i = 0;
    public List<AudioClip> audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMesh CodeText;
    [SerializeField] GameObject tasks; 

    void Start()
    {
        Code = "XXXX";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CodeText.text = Code;
        if(Code == CorrCode) 
        {
            tasks.GetComponent<Tasks>().addPoint();
            Code = "XXXX";
        }
    }
    public void addDigit(string letter) 
    {
        if (Code.Length < 4) {
            Code = Code.Insert(0,letter);
        }
        else {
            Code = Code.Remove(0, 1);
            //Code = Code.Substring(0, 3);
            Code = Code + letter;
        }
        Debug.Log(Code);
    }
    public void setCorrCode(string code) 
    {
        CorrCode = code;
    }
    public void failedTask() 
    {
        tasks.GetComponent<Tasks>().subPoint();
        CorrCode = "ABCD";
    }


    

}

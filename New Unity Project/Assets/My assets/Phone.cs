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
    void Start()
    {
        Code = "XXXX";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CodeText.text = Code;
        //if (!audioSource.isPlaying) { audioSource.PlayOneShot(audioClips[i]); i++; }

        
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

    

}

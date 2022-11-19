using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAudio : MonoBehaviour
{
    public AudioSource bossMelee;
    public bool meleeAudioPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(meleeAudioPlay == true)
        {
            bossMelee.Play();
        }
        else
        {
            bossMelee.Stop(); ;
        }
    }
}

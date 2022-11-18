using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
public class BossEnrage : MonoBehaviour
{
    
    [SerializeField] Enemy enemy;
    public AudioSource bossEnrage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.IsEnrage == true)
        {
            bossEnrage.Play();
        }
        if(enemy.isdead == true)
        {
            bossEnrage.Stop();
        }
    }
}

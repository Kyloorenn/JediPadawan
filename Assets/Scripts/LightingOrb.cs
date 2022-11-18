using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Media;
//using System.Runtime.Remoting.Activation;
using UnityEngine;

public class LightingOrb : BaseWeapon
{

    [SerializeField] GameObject lightingorb;
    private int orbNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(orbNumber < level)
        {
            Instantiate(lightingorb);
            orbNumber++;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSaber : BaseWeapon
{
    [SerializeField] GameObject Player;   
    public GameObject LightSaber;
    public float CD = 7;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        CD = 7 - level;
    }

    // Update is called once per frame
    void Update()
    {                                                                                                                                           
        if (Input.GetKeyDown(KeyCode.K)&&isOpen == false)
        {           
            isOpen = true;
            Instantiate(LightSaber, transform.position, transform.rotation);
            
        }
      
            
        if (isOpen == true)
        {
            CD -= Time.deltaTime;
        }

        if (CD <= 0)
        {          
            CD = 7 - level;
            isOpen = false;
        }
    }

   
}

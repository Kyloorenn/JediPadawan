using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int level = 0;

    internal void LevelUP()
    {
        if (++level >= 1)
        {
            gameObject.SetActive(true);
        }
        //level up 0 -> 1;       
    }
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {   
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class Choose2 : MonoBehaviour
{
    [SerializeField] Text choice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Titlemanage.saveData.buyFighter == true)
        {
            choice.text = "choose";
        }
        else
        {
            choice.text = "LOCKED";
        }
    }
}

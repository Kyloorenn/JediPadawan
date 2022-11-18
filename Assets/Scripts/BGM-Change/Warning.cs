using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField] TMP_Text Timer;
    [SerializeField] GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Timer.text =="03:50")
        {
            warning.SetActive(true);
        
        }
    }
}

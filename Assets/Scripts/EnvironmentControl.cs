using System;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnvironmentControl : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;
    [SerializeField] GameObject snow;
    [SerializeField] GameObject wind;
    [SerializeField] GameObject outbreak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerText.text == "01:00")
        {
            wind.SetActive(true);
        }else if(TimerText.text == "02:00")
        {
            snow.SetActive(true);
            wind.SetActive(false);
        }else if(TimerText.text == "03:00")
        {
            outbreak.SetActive(true);
            snow.SetActive(false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class In_GameProcessing : MonoBehaviour
{
    [SerializeField] TMP_Text in_Game;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Titlemanage.saveData.gameProcessing == true)
        {
            in_Game.text = "ON";
        }else
            {
            in_Game.text = "OFF";
        }
    }
}

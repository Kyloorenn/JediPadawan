using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;


public class BeforeBossEnter : MonoBehaviour
{
    [SerializeField] TMP_Text Timer;
    [SerializeField] Enemy enemy;
    public AudioSource BossWarning;

    void Update()
    {
        if(Timer.text == "03:46")
        {
            BossWarning.Play();
        }
        if(enemy.IsEnrage == true)
        {
            BossWarning.Stop();
        }
    }
}

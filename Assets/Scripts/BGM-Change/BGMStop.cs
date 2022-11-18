using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class BGMStop : MonoBehaviour
{
    [SerializeField] TMP_Text Timer;
    public AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
   
     }

    // Update is called once per frame
    void Update()
    {
    if (Timer.text == "03:45")
    {
        BGM.Stop();
    }
}
}

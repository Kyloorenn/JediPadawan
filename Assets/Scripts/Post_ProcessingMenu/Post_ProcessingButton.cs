using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Post_ProcessingButton : MonoBehaviour
{
    [SerializeField] TMP_Text post_Processing;
    TitleCamera titleCamera;
    // Start is called before the first frame update
    void Start()
    {
        titleCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TitleCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (titleCamera.volume.enabled == true)
        {
            post_Processing.text = "ON";

        }
        else
        {
            post_Processing.text = "OFF";

        }
    }
}

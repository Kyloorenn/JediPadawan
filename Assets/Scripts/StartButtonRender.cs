using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonRender : MonoBehaviour
{
    TitleCamera titleCamera;
    // Start is called before the first frame update
    void Start()
    {
        titleCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TitleCamera>(); //use method from TitileCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                titleCamera.TitleLensBlur();
                UnityEngine.Debug.Log("Click the Start button.");
            }
        }
        else
        {
            titleCamera.NormalLensBlur();
        }

    }
}

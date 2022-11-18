using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpError : MonoBehaviour
{


    private float InfoTimer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InfoTimer > 0)
        {

            InfoTimer -= Time.deltaTime;
        }
        if (InfoTimer <= 0)
        {

            InfoTimer = 1.5f;
            gameObject.SetActive(false);

        }

    }
}

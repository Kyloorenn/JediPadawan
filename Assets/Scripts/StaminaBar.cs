using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image Staminabar;
    // Start is called before the first frame update
    void Start()
    {
        if (!player && Titlemanage.saveData.isone == true)
        {
            player = GameObject.Find("Padawan").GetComponent<Player>();

        }
        else if (!player && Titlemanage.saveData.istwo == true)
        {
            player = GameObject.Find("Fighter").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float staRatio = (float)player.currentstamina / player.maxstamina;
        Staminabar.transform.localScale = new Vector3(staRatio, 1, 1);
    }
}

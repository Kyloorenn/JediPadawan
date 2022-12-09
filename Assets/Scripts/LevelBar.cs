using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class LevelBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text levelBar;
    private void Start()
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
    private void Update()
    {
        float level = (float)player.currentLevel;

        levelBar.text = "Lv: " + level;
    }
}
